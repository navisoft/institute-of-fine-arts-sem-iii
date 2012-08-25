using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;
using eProjectsSemIII.Models;
using System.Text;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class ExhibitionsController : AuthenticationController
    {
        public ActionResult Index(string id)
        {
            base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Exhibitions exhibitionsModels = new Exhibitions();
            decimal totalExhibition = exhibitionsModels.TotalExhibition();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalExhibition / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/exhibitions/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Exhibitions";
            return View(exhibitionsModels.ListExhibition((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult ExhibitionDesign(string id)
        {
            base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Designs designsModels = new Designs();
                designsModels.ID = idd;
                designsModels = designsModels.GetNavigationWithID("Exhibitions");
                ViewBag.Title += " Exhinitions of " + designsModels.Name + " Designs";
                ViewBag.designID = idd;
                Session["back-url"] = "~/administrator/exhibitions/exhibitiondesign/" + idd;
                return View(designsModels.Exhibitions.ToList());
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }

        public ActionResult AddExhibitionDesign(string id,FormCollection form)
        {
            base.Authentication();
            base.LoadMenu();
            try
            {
                var db = new FineArtContext();
                int idd = Convert.ToInt16(id);
                ViewBag.exhibitionID = idd;
                var design = db.Designs.Include("Exhibitions").Where(d => d.ID == idd).First();
                var listExhibitions = db.Exhibitions
                    .Where(e => e.EndDate > DateTime.Now)
                    .ToList();
                ViewBag.listExhibitions = listExhibitions.Except(design.Exhibitions).ToList();
                if (form["submit_exhibition"] != null)
                {
                    Strings stringModels = new Strings();
                    int[] IDExhibitions = stringModels.ListID(form["Exhibitions"]);
                    ViewBag.IDExhibitions = IDExhibitions;
                    ICollection<Exhibitions> listExhibitionsOther = db.Exhibitions.Where(s => IDExhibitions.Contains(s.ID)).ToList();
                    foreach (Exhibitions ex in listExhibitionsOther)
                    {
                        design.Exhibitions.Add(ex);
                    }
                    db.SaveChanges();
                    return Redirect("~/administrator/exhibitions/addexhibitiondesign/" + idd);
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return null;
            }
        }

        public RedirectResult RemoveExhibitionDesign(string id, string param)
        {
            base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                int paramm = Convert.ToInt16(param);
                var db = new FineArtContext();
                var design = db.Designs.Include("Exhibitions").Where(d => d.ID == paramm).First();
                var exhibition = design.Exhibitions.Where(e => e.ID == idd).First();
                design.Exhibitions.Remove(exhibition);
                db.SaveChanges();
                return Redirect("~/administrator/exhibitions/exhibitiondesign/" + paramm);
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }

        public ActionResult Add(FormCollection form, HttpPostedFileBase Images)
        {
            base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            if (form["submit_exhibition"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type exhibition name</li>");
                }
                if (form["Alias"].Trim() == "" || !Validator.ISAlias(form["Alias"]))
                {
                    stringBuilder.Append("<li>Please type exhibition alias</li>");
                }
                else
                {
                    try
                    {
                        string alias = form["Alias"].Trim().ToString();
                        var exhibition = db.Exhibitions.Where(c => c.Alias == alias).First();
                        stringBuilder.Append("<li>This exhibition alias had been exists in database, try a different</li>");
                    }
                    catch { }
                }
                if (form["Description"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type exhibition description</li>");
                }
                DateTime StartDate = new DateTime();
                DateTime EndDate = new DateTime();
                try
                {
                    StartDate = DateTime.Parse(form["StartDate"]);
                }
                catch
                {
                    stringBuilder.Append("<li>Please type exhibition start date</li>");
                }
                try
                {
                    EndDate = DateTime.Parse(form["EndDate"]);
                }
                catch
                {
                    stringBuilder.Append("<li>Please type exhibition deadline date</li>");
                }
                try
                {
                    if (DateTime.Parse(form["EndDate"]) <= DateTime.Parse(form["StartDate"]))
                    {
                        stringBuilder.Append("<li>End date should after start date</li>");
                    }
                }
                catch
                {

                }
                if (Images == null)
                {
                    stringBuilder.Append("<li>Please chose a image for this exhibition</li>");
                }
                if (stringBuilder.ToString() == "<ul>")
                {
                    ImagesClass objImageClass = new ImagesClass(Images);
                    string fileSaveName = Server.MapPath("~/Content/Images/exhibitions/" + form["Alias"] + ".jpg");
                    objImageClass.CreateNewImage(fileSaveName, 190, 190);
                    Exhibitions exhibitionsModels = new Exhibitions
                    {
                        Name = form["Name"].Trim(),
                        Alias = form["Alias"].Trim(),
                        Image = form["Alias"].Trim() + ".jpg",
                        StartDate = StartDate,
                        EndDate = EndDate,
                        Description = form["Description"].Trim()
                    };
                    db.Exhibitions.Add(exhibitionsModels);
                    db.SaveChanges();
                    ViewBag.success = "Add exhibition success!";
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
            base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                Exhibitions exhibition = db.Exhibitions.Where(c => c.ID == idd).First();
                if (form["submit_exhibition"] == null)
                {
                    form["Name"] = exhibition.Name;
                    form["Alias"] = exhibition.Alias;
                    form["StartDate"] = exhibition.StartDate.ToString("dd/MM/yyyy");
                    form["EndDate"] = exhibition.EndDate.ToString("dd/MM/yyyy");
                    form["Description"] = exhibition.Description;
                    ViewBag.dataForm = form;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type exhibition name</li>");
                    }
                    if (form["Alias"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type exhibition alias</li>");
                    }
                    else
                    {
                        if (form["Alias"].Trim() != exhibition.Alias)
                        {
                            try
                            {
                                string alias = form["Alias"].Trim().ToString();
                                var exhibitions = db.Exhibitions.Where(c => c.Alias == alias).First();
                                stringBuilder.Append("<li>This competition alias had been exists in database, try a different</li>");
                            }
                            catch { }
                        }
                    } 
                    if (form["Description"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type exhibition description</li>");
                    }
                    DateTime StartDate = new DateTime();
                    DateTime EndDate = new DateTime();
                    try
                    {
                        StartDate = DateTime.Parse(form["StartDate"]);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Please type exhibition start date</li>");
                    }
                    try
                    {
                        EndDate = DateTime.Parse(form["EndDate"]);
                    }
                    catch
                    {
                        stringBuilder.Append("<li>Please type exhibition deadline date</li>");
                    }
                    try
                    {
                        if (DateTime.Parse(form["EndDate"]) <= DateTime.Parse(form["StartDate"]))
                        {
                            stringBuilder.Append("<li>End date should after start date</li>");
                        }
                    }
                    catch
                    {

                    }

                    if (stringBuilder.ToString() == "<ul>")
                    {
                        if (Images != null)
                        {
                            string fileOldName = Server.MapPath("~/Content/Images/exhibitions/" + exhibition.Alias + ".jpg");
                            FilesClass.DeleteFile(fileOldName);
                            ImagesClass objImageClass = new ImagesClass(Images);
                            string fileSaveName = Server.MapPath("~/Content/Images/exhibitions/" + form["Alias"] + ".jpg");
                            objImageClass.CreateNewImage(fileSaveName, 190, 190);
                        }
                        else
                        {
                            if (form["Alias"].Trim() != exhibition.Alias)
                            {
                                string fileOldName = Server.MapPath("~/Content/Images/exhibitions/" + exhibition.Alias + ".jpg");
                                string fileNewName = Server.MapPath("~/Content/Images/exhibitions/" + form["Alias"] + ".jpg");
                                FilesClass.RenameFile(fileOldName, fileNewName);
                            }
                        }
                        Exhibitions exhibitionsModels;
                        exhibitionsModels = db.Exhibitions.Where(c => c.ID == idd).First();
                        exhibitionsModels.Name = form["Name"];
                        exhibitionsModels.Alias = form["Alias"];
                        exhibitionsModels.Image = form["Alias"] + ".jpg";
                        exhibitionsModels.StartDate = StartDate;
                        exhibitionsModels.EndDate = EndDate;
                        exhibitionsModels.Description = form["Description"].Trim();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update exhibition success!";
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
            base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                var exhibitionsModels = db.Exhibitions.Where(c => c.ID == idd).First();
                List<Customers> listCustomer = db.Customers.Where(c => c.Exhibition.ID == exhibitionsModels.ID).ToList();
                listCustomer.ForEach(delegate(Customers customer)
                {
                    customer.Exhibition = null;
                });

                db.SaveChanges();
                db.Exhibitions.Remove(exhibitionsModels);
                db.SaveChanges();
                return Redirect("~/administrator/exhibitions/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }

        }
    }
}
