using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;
using System.Text;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class KindsController : AuthenticationController
    {
        //
        // GET: /Administrator/Kinds/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Kinds kindsModels = new Kinds();
            decimal totalKind = kindsModels.TotalKind();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalKind / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/kinds/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Kinds";
            return View(kindsModels.ListKind((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult KindCompetition(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Competitions competitionsModels = new Competitions();
                competitionsModels.ID = idd;
                competitionsModels = competitionsModels.ListNavigation("Kind");
                ViewBag.Title += " Kinds of "+competitionsModels.Name + " Competition";
                return View(competitionsModels.Kind.ToList());
            }
            catch
            {
                return Redirect("~/");
            }
        }

        public ActionResult Add(FormCollection form)
        {
            //base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            if (form["submit_kind"] != null)
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
                else if(!Validator.ISAlias(form["Alias"]))
                {
                    stringBuilder.Append("<li>Competition alias unvalid</li>");
                }
                if (stringBuilder.ToString() == "<ul>")
                {
                    Kinds kind = new Kinds { Name = form["Name"], Alias = form["Alias"], DateUpdate = DateTime.Now, Description = form["Description"] };
                    db.Kinds.Add(kind);
                    db.SaveChanges();
                    ViewBag.success = "Add kind success!";
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

        public ActionResult Edit(string id,FormCollection form)
        {
            //base.Authentication();
            var db = new FineArtContext();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Kinds kind = db.Kinds.Where(k => k.ID == idd).FirstOrDefault();
                if (form["submit_kind"] == null)
                {
                    form["Name"] = kind.Name;
                    form["Alias"] = kind.Alias;
                    form["Description"] = kind.Description;
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
                    if (form["Alias"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition alias</li>");
                    }
                    else if (!Validator.ISAlias(form["Alias"]))
                    {
                        stringBuilder.Append("<li>Competition alias unvalid</li>");
                    }
                    else if(form["Alias"].Trim() != kind.Alias)
                    {
                        try
                        {
                            string alias = form["Alias"].Trim();
                            Kinds kindOther = db.Kinds.Where(k => k.Alias == alias).First();
                            stringBuilder.Append("<li>This kind alias had been in database, try a different</li>");
                        }
                        catch { }
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        kind.Name = form["Name"];
                        kind.Alias = form["Alias"];
                        kind.Description = form["Description"].Trim();
                        db.SaveChanges();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update kind success!";
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
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                Kinds kind = db.Kinds.Where(k => k.ID == idd).First();
                db.Kinds.Remove(kind);
                db.SaveChanges();
                return Redirect("~/administrator/kinds/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }

        }
    }
}
