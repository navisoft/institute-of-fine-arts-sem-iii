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
                return Redirect("~/");
            }
        }

        [HttpPost]
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
                if (form["Alias"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type competition alias</li>");
                }
                else
                {
                    try
                    {
                        string alias = form["Alias"].Trim().ToString();
                        var competition = db.Competitions.Where(c => c.Alias == alias).First();
                        stringBuilder.Append("<li>This competition alias had been in database, try a different</li>");
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
                    Competitions competitionsModels = new Competitions
                    {
                        Name = form["Name"],
                        Alias = form["Alias"],
                        Images = form["Alias"]+".jpg",
                        Staffs = listStaffs,
                        Condition = listConditions,
                        Award = listAwards,
                        Kind = listKinds,
                        StartDate = StartDate,
                        DeadlineDate = DeadlineDate,
                        EndDate = EndDate,
                        Summary = form["Summary"]
                    };
                    db.Competitions.Add(competitionsModels);
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
                return Redirect("~/");
            }

        }
        public ActionResult Edit(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                Competitions competitonsModels;
                competitonsModels = db.Competitions.Where(c => c.ID == idd).FirstOrDefault();
                competitonsModels.Name = "New Name2";
                db.SaveChanges();
                return Redirect("~/administrator/competitions/");
            }
            catch
            {
                return Redirect("~/");
            }
        }
    }
}
