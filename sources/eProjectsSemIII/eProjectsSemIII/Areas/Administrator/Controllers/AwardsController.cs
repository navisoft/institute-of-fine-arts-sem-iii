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
    public class AwardsController : AuthenticationController
    {
        //
        // GET: /Administrator/Awards/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Awards awardsModels = new Awards();
            decimal totalAward = awardsModels.TotalAward();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalAward / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/awards/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Awards";
            return View(awardsModels.ListAward((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }
        public ActionResult AwardCompetition(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Competitions competitionsModels = new Competitions();
                competitionsModels.ID = idd;
                competitionsModels = competitionsModels.ListNavigation("Award");
                ViewBag.Title += " Awards of " + competitionsModels.Name + " Competition";
                return View(competitionsModels.Award.ToList());
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }

        public ActionResult Add(FormCollection form)
        {
            //base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            if (form["submit_award"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type competition name</li>");
                }
                if (form["Description"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type competition description</li>");
                }
                if (stringBuilder.ToString() == "<ul>")
                {
                    Awards award = new Awards { Name = form["Name"], DateUpdate = DateTime.Now, Description = form["Description"].Trim() };
                    db.Awards.Add(award);
                    db.SaveChanges();
                    ViewBag.success = "Add award success!";
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

        public ActionResult Edit(string id, FormCollection form)
        {
            //base.Authentication();
            var db = new FineArtContext();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Awards award = db.Awards.Where(a => a.ID == idd).FirstOrDefault();
                if (form["submit_award"] == null)
                {
                    form["Name"] = award.Name;
                    form["Description"] = award.Description;
                    ViewBag.dataForm = form;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition name</li>");
                    }
                    if (form["Description"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition description</li>");
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        award.Name = form["Name"];
                        award.Description = form["Description"].Trim();
                        db.SaveChanges();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update award success!";
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
                Awards award = db.Awards.Where(a => a.ID == idd).First();
                db.Awards.Remove(award);
                db.SaveChanges();
                return Redirect("~/administrator/awards/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
    }
}
