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
    public class ConditionsController : AuthenticationController
    {
        //
        // GET: /Administrator/Conditions/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Conditions conditionsModels = new Conditions();
            decimal totalCondition = conditionsModels.TotalCondition();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalCondition / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/conditions/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Conditions";
            return View(conditionsModels.ListCondition((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }
        public ActionResult ConditionCompetition(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Competitions competitionsModels = new Competitions();
                competitionsModels.ID = idd;
                competitionsModels = competitionsModels.ListNavigation("Condition");
                ViewBag.Title += " Conditions of "+competitionsModels.Name + " Competition";
                return View(competitionsModels.Condition.ToList());
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
            if (form["submit_condition"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type condition name</li>");
                }
                if (form["Description"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type condition description</li>");
                }
                if (stringBuilder.ToString() == "<ul>")
                {
                    Conditions condition = new Conditions { Name = form["Name"], DateUpdate = DateTime.Now, Description = form["Description"].Trim() };
                    db.Conditions.Add(condition);
                    db.SaveChanges();
                    ViewBag.success = "Add condition success!";
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
                Conditions condition = db.Conditions.Where(c => c.ID == idd).FirstOrDefault();
                if (form["submit_condition"] == null)
                {
                    form["Name"] = condition.Name;
                    form["Description"] = condition.Description;
                    ViewBag.dataForm = form;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type condition name</li>");
                    }
                    if (form["Description"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type condition description</li>");
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        condition.Name = form["Name"];
                        condition.Description = form["Description"].Trim();
                        db.SaveChanges();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update condition success!";
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
                Conditions condition = db.Conditions.Where(c => c.ID == idd).First();
                db.Conditions.Remove(condition);
                db.SaveChanges();
                return Redirect("~/administrator/conditions/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
    }
}
