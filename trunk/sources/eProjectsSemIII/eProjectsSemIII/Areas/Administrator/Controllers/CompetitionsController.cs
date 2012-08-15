using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eProjectsSemIII.Configs;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Models;
using System.Text;
using System.Web;
using System.Drawing;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{   
    /**
     * Class: CompetitionController
     * Manage Competitions
     * Author: Le Dang Son
     * Date: 08/08/2012
     */

    public class CompetitionsController : AuthenticationController
    {
        /**
         * Controller: Competition
         * Action: Index
         * List all competitions
         * Author: Le Dang Son
         * Date: 08/08/2012
         */
        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Competitions competitionsModels = new Competitions();
            decimal totalCompetition = competitionsModels.TotalCompetition();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalCompetition / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/competitions/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Competitions";
            return View(competitionsModels.ListCompetition((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult CompetitionKind(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Kinds kindsModels = new Kinds();
                kindsModels.ID = idd;
                kindsModels = kindsModels.GetNavigationWithID("Competition");
                ViewBag.Title += " Competition have " + kindsModels.Name + " Kind";
                return View(kindsModels.Competition.ToList());
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
        
        public ActionResult Add(FormCollection form, HttpPostedFileBase Images)
        {
            //base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            ViewBag.listStaff = db.Members.Where(m => m.Role.ID == 3).ToList();
            ViewBag.listCOndition = db.Conditions.ToList();
            ViewBag.listAward = db.Awards.ToList();
            ViewBag.listKind = db.Kinds.ToList();
            if (form["submit_competition"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type competition name</li>");
                }
                if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                {
                    stringBuilder.Append("<li>Please type competition alias</li>");
                }
                else
                {
                    try
                    {
                        string alias = form["Alias"].Trim().ToString();
                        var competition = db.Competitions.Where(c => c.Alias == alias).First();
                        stringBuilder.Append("<li>This competition alias had been exists in database, try a different</li>");
                    }
                    catch { }
                }
                int[] IDStaffs = stringsLibs.ListID(form["Staffs"]);
                int[] IDConditions = stringsLibs.ListID(form["Conditions"]);
                int[] IDAwards = stringsLibs.ListID(form["Awards"]);
                int[] IDKinds = stringsLibs.ListID(form["Kinds"]);
                ViewBag.IDStaffs = IDStaffs;
                ViewBag.IDConditions = IDConditions;
                ViewBag.IDAwards = IDAwards;
                ViewBag.IDKinds = IDKinds;
                ICollection<Members> listStaffs = db.Members.Where(s => IDStaffs.Contains(s.ID)).ToList();
                ICollection<Conditions> listConditions = db.Conditions.Where(c => IDConditions.Contains(c.ID)).ToList();
                ICollection<Awards> listAwards = db.Awards.Where(a => IDAwards.Contains(a.ID)).ToList();
                ICollection<Kinds> listKinds = db.Kinds.Where(k => IDKinds.Contains(k.ID)).ToList();
                if (listStaffs.Count == 0)
                {
                    stringBuilder.Append("<li>Please chose teachers scoring for this competition</li>");
                }
                if (listConditions.Count == 0)
                {
                    stringBuilder.Append("<li>Please chose conditions for this competition</li>");
                }
                if (listAwards.Count == 0)
                {
                    stringBuilder.Append("<li>Please chose awards for this competition</li>");
                }
                if (listKinds.Count == 0)
                {
                    stringBuilder.Append("<li>Please chose kinds for this competition</li>");
                }
                DateTime StartDate = new DateTime();
                DateTime DeadlineDate = new DateTime();
                DateTime EndDate = new DateTime();
                try
                {
                    StartDate = DateTime.Parse(form["StartDate"]);
                }
                catch
                {
                    stringBuilder.Append("<li>Please type competition start date</li>");
                }
                try
                {
                    DeadlineDate = DateTime.Parse(form["DeadlineDate"]);
                }
                catch
                {
                    stringBuilder.Append("<li>Please type competition deadline date</li>");
                }
                try
                {
                    EndDate = DateTime.Parse(form["EndDate"]);
                }
                catch
                {
                    stringBuilder.Append("<li>Please type competition deadline date</li>");
                }
                try
                {
                    if (DateTime.Parse(form["DeadlineDate"]) <= DateTime.Parse(form["StartDate"]))
                    {
                        stringBuilder.Append("<li>Deadline date should after start date</li>");
                    }
                }
                catch
                {

                }
                try
                {
                    if (DateTime.Parse(form["EndDate"]) <= DateTime.Parse(form["DeadlineDate"]))
                    {
                        stringBuilder.Append("<li>End date should after deadline date</li>");
                    }
                }
                catch
                {

                }

                if (Images == null)
                {
                    stringBuilder.Append("<li>Please chose a image for this competition</li>");
                }
                if (stringBuilder.ToString() == "<ul>")
                {
                    ImagesClass objImageClass = new ImagesClass(Images);
                    string fileSaveName = Server.MapPath("~/Content/Images/competitions/"+form["Alias"]+".jpg");
                    objImageClass.CreateNewImage(fileSaveName, 190, 190);
                    Competitions competitionsModels = new Competitions
                    {
                        Name = form["Name"],
                        Alias = form["Alias"],
                        Images = form["Alias"] + ".jpg",
                        Staffs = listStaffs,
                        Condition = listConditions,
                        Award = listAwards,
                        Kind = listKinds,
                        StartDate = StartDate,
                        DeadlineDate = DeadlineDate,
                        EndDate = EndDate,
                        Summary = form["Summary"].Trim()
                    };
                    db.Competitions.Add(competitionsModels);
                    db.SaveChanges();
                    ViewBag.success = "Add competition success!";
                }
                else
                {
                    stringBuilder.Append("</ul>");
                    ViewBag.error = stringBuilder.ToString();
                    ViewBag.dataForm = form;
                }
            }
            return View();
        }
        public ActionResult Edit(string id, FormCollection form, HttpPostedFileBase Images)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                ICollection<Members> listStaffs;
                ICollection<Conditions> listConditions;
                ICollection<Awards> listAwards;
                ICollection<Kinds> listKinds;
                int[] IDStaffs;
                int[] IDConditions;
                int[] IDAwards;
                int[] IDKinds;

                Competitions competiton = db.Competitions.Include("Staffs").Include("Condition").Include("Award").Include("Kind").Where(c => c.ID == idd).FirstOrDefault();

                ViewBag.listStaff = db.Members.Where(m => m.Role.ID == 3).ToList();
                ViewBag.listCOndition = db.Conditions.ToList();
                ViewBag.listAward = db.Awards.ToList();
                ViewBag.listKind = db.Kinds.ToList();
                if (form["submit_competition"] == null)
                {
                    form["Name"] = competiton.Name;
                    form["Alias"] = competiton.Alias;
                    form["StartDate"] = competiton.StartDate.ToString("dd/MM/yyyy");
                    form["DeadlineDate"] = competiton.DeadlineDate.ToString("dd/MM/yyyy"); ;
                    form["EndDate"] = competiton.EndDate.ToString("dd/MM/yyyy");
                    form["Summary"] = competiton.Summary;
                    ViewBag.dataForm = form;

                    listStaffs = competiton.Staffs;
                    listConditions = competiton.Condition;
                    listAwards = competiton.Award;
                    listKinds = competiton.Kind;
                    IDStaffs = new int[listStaffs.Count];
                    IDConditions = new int[listConditions.Count];
                    IDAwards = new int[listAwards.Count];
                    IDKinds = new int[listKinds.Count];
                    int i = 0;
                    foreach (Members member in listStaffs)
                    {
                        IDStaffs[i] = member.ID;
                        i++;
                    }
                    i = 0;
                    foreach (Conditions condition in listConditions)
                    {
                        IDConditions[i] = condition.ID;
                        i++;
                    }
                    i = 0;
                    foreach (Awards award in listAwards)
                    {
                        IDAwards[i] = award.ID;
                        i++;
                    }
                    i = 0;
                    foreach (Kinds kind in listKinds)
                    {
                        IDKinds[i] = kind.ID;
                        i++;
                    }

                    ViewBag.IDStaffs = IDStaffs;
                    ViewBag.IDConditions = IDConditions;
                    ViewBag.IDAwards = IDAwards;
                    ViewBag.IDKinds = IDKinds;
                }else{
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition name</li>");
                    }
                    if (form["Alias"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition alias</li>");
                    }
                    else
                    {
                        if (form["Alias"].Trim() != competiton.Alias)
                        {
                            try
                            {
                                string alias = form["Alias"].Trim().ToString();
                                var competition = db.Competitions.Where(c => c.Alias == alias).First();
                                stringBuilder.Append("<li>This competition alias had been exists in database, try a different</li>");
                            }
                            catch { }
                        }
                    }
                    IDStaffs = stringsLibs.ListID(form["Staffs"]);
                    IDConditions = stringsLibs.ListID(form["Conditions"]);
                    IDAwards = stringsLibs.ListID(form["Awards"]);
                    IDKinds = stringsLibs.ListID(form["Kinds"]);
                    ViewBag.IDStaffs = IDStaffs;
                    ViewBag.IDConditions = IDConditions;
                    ViewBag.IDAwards = IDAwards;
                    ViewBag.IDKinds = IDKinds;
                    listStaffs = db.Members.Where(s => IDStaffs.Contains(s.ID)).ToList();
                    listConditions = db.Conditions.Where(c => IDConditions.Contains(c.ID)).ToList();
                    listAwards = db.Awards.Where(a => IDAwards.Contains(a.ID)).ToList();
                    listKinds = db.Kinds.Where(k => IDKinds.Contains(k.ID)).ToList();
                    if (listStaffs.Count == 0)
                    {
                        stringBuilder.Append("<li>Please chose teachers scoring for this competition</li>");
                    }
                    if (listConditions.Count == 0)
                    {
                        stringBuilder.Append("<li>Please chose conditions for this competition</li>");
                    }
                    if (listAwards.Count == 0)
                    {
                        stringBuilder.Append("<li>Please chose awards for this competition</li>");
                    }
                    if (listKinds.Count == 0)
                    {
                        stringBuilder.Append("<li>Please chose kinds for this competition</li>");
                    }
                    DateTime StartDate = new DateTime();
                    DateTime DeadlineDate = new DateTime();
                    DateTime EndDate = new DateTime();
                    try
                    {
                        StartDate = DateTime.Parse(form["StartDate"]);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Please type competition start date</li>");
                    }
                    try
                    {
                        DeadlineDate = DateTime.Parse(form["DeadlineDate"]);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Please type competition deadline date</li>");
                    }
                    try
                    {
                        EndDate = DateTime.Parse(form["EndDate"]);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Please type competition deadline date</li>");
                    }
                    try
                    {
                        if (DateTime.Parse(form["DeadlineDate"]) <= DateTime.Parse(form["StartDate"]))
                        {
                            stringBuilder.Append("<li>Deadline date should after start date</li>");
                        }
                    }
                    catch
                    {

                    }
                    try
                    {
                        if (DateTime.Parse(form["EndDate"]) <= DateTime.Parse(form["DeadlineDate"]))
                        {
                            stringBuilder.Append("<li>End date should after deadline date</li>");
                        }
                    }
                    catch
                    {

                    }

                    if (stringBuilder.ToString() == "<ul>")
                    {
                        if (Images != null)
                        {
                            string fileOldName = Server.MapPath("~/Content/Images/competitions/" + competiton.Alias + ".jpg");
                            FilesClass.DeleteFile(fileOldName);
                            ImagesClass objImageClass = new ImagesClass(Images);
                            string fileSaveName = Server.MapPath("~/Content/Images/competitions/" + form["Alias"] + ".jpg");
                            objImageClass.CreateNewImage(fileSaveName, 190, 190);
                        }
                        else
                        {
                            if (form["Alias"].Trim() != competiton.Alias)
                            {
                                string fileOldName = Server.MapPath("~/Content/Images/competitions/" + competiton.Alias + ".jpg");
                                string fileNewName = Server.MapPath("~/Content/Images/competitions/" + form["Alias"] + ".jpg");
                                FilesClass.RenameFile(fileOldName, fileNewName);
                            }
                        }
                        Competitions competitonsModels;
                        competitonsModels = db.Competitions.Where(c => c.ID == idd).FirstOrDefault();
                        competitonsModels.Name = form["Name"];
                        competitonsModels.Alias = form["Alias"];
                        competitonsModels.Images = form["Alias"] + ".jpg";
                        competitonsModels.StartDate = StartDate;
                        competitonsModels.DeadlineDate = DeadlineDate;
                        competitonsModels.EndDate = EndDate;
                        competitonsModels.Staffs = listStaffs;
                        competitonsModels.Condition = listConditions;
                        competitonsModels.Award = listAwards;
                        competitonsModels.Kind = listKinds;
                        competitonsModels.Summary = form["Summary"].Trim();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update competition success!";
                        db.SaveChanges();
                    }
                    else
                    {
                        stringBuilder.Append("</ul>");
                        ViewBag.error = stringBuilder.ToString();
                        ViewBag.dataForm = form;
                    }
                }
                
                return View();
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
        public ActionResult Delete(string id)
        {
            //base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                var competitionsModels = db.Competitions.Include("Design").Where(c => c.ID == idd).FirstOrDefault();
                var listDesign = competitionsModels.Design.ToList();
                listDesign.ForEach(delegate(Designs ds)
                {
                    var listMark = db.Marks.Where(m => m.Design.ID == ds.ID).ToList();
                    listMark.ForEach(delegate(Marks mk)
                    {
                        db.Marks.Remove(mk);
                    });
                    var listCustomer = db.Customers.Where(c => c.Design.ID == ds.ID).ToList();
                    listCustomer.ForEach(delegate(Customers cus)
                    {
                        db.Customers.Remove(cus);
                    });
                    db.Designs.Remove(ds);
                });
                db.Competitions.Remove(competitionsModels);
                db.SaveChanges();
                return Redirect("~/administrator/competitions/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }

        }
    }
}
