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
    public class ClassesController : AuthenticationController
    {
        //
        // GET: /Administrator/Classes/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Classes classesModels = new Classes();
            decimal totalClasses = classesModels.TotalClasses();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalClasses / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/classes/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Classes";
            return View(classesModels.ListClasses((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }
        public ActionResult Add(FormCollection form)
        {
            //base.Authentication();
            base.LoadMenu();
            var db = new FineArtContext();
            if (form["submit_class"] != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<ul>");
                Strings stringsLibs = new Strings();
                if (form["Name"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type class name</li>");
                }
                if (form["Alias"].Trim() == "")
                {
                    stringBuilder.Append("<li>Please type class alias</li>");
                }
                else
                {
                    try
                    {
                        string alias = form["Alias"].Trim().ToString();
                        var classModels = db.Classes.Where(c => c.Alias == alias).First();
                        stringBuilder.Append("<li>This class alias had been exists in database, try a different</li>");
                    }
                    catch { }
                }

                if (stringBuilder.ToString() == "<ul>")
                {
                    Classes classModels = new Classes { Name = form["Name"],Alias=form["Alias"], DateUpdate = DateTime.Now};
                    db.Classes.Add(classModels);
                    db.SaveChanges();
                    ViewBag.success = "Add class success!";
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
                Classes classModels = db.Classes.Where(c => c.ID == idd).FirstOrDefault();
                if (form["submit_class"] == null)
                {
                    form["Name"] = classModels.Name;
                    form["Alias"] = classModels.Alias;
                    ViewBag.dataForm = form;
                }
                else
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type class name</li>");
                    }
                    if (form["Alias"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type class alias</li>");
                    }
                    else if(form["Alias"] != classModels.Alias)
                    {
                        try
                        {
                            string alias = form["Alias"].Trim().ToString();
                            var classes = db.Classes.Where(c => c.Alias == alias).First();
                            stringBuilder.Append("<li>This class alias had been exists in database, try a different</li>");
                        }
                        catch { }
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        classModels.Name = form["Name"];
                        classModels.Alias = form["Alias"];
                        db.SaveChanges();
                        ViewBag.dataForm = form;
                        ViewBag.success = "Update class success!";
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
                Classes classes = db.Classes.Where(c => c.ID == idd).First();
                db.Classes.Remove(classes);
                db.SaveChanges();
                return Redirect("~/administrator/classes/");
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
    }
}
