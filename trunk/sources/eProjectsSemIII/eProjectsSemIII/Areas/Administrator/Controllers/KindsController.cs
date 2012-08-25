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
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult KindCompetition(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                try
                {
                    int idd = Convert.ToInt16(id);
                    ViewBag.competitionID = idd;
                    Competitions competitionsModels = new Competitions();
                    competitionsModels.ID = idd;
                    competitionsModels = competitionsModels.ListNavigation("Kind");
                    ViewBag.Title += " Kinds of " + competitionsModels.Name + " Competition";
                    return View(competitionsModels.Kind.ToList());
                }
                catch
                {
                    Session["admin"] = null;
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult RemoveKindCompetition(string id, string param)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int kindID = Convert.ToInt16(id);
                    int competitionID = Convert.ToInt16(param);
                    var db = new FineArtContext();
                    var competition = db.Competitions.Include("Kind").Where(c => c.ID == competitionID).First();
                    var kind = db.Kinds.Where(k => k.ID == kindID).First();
                    competition.Kind.Remove(kind);
                    db.SaveChanges();
                    return Redirect("~/administrator/kinds/kindcompetition/" + competitionID);
                }
                catch
                {
                    Session["admin"] = null;
                    return Redirect("~/");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult AddKindCompetition(string id, FormCollection form)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                base.LoadMenu();
                try
                {
                    int idd = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    ViewBag.competitionID = idd;
                    var competition = db.Competitions.Include("Kind").Where(c => c.ID == idd && c.DeadlineDate > DateTime.Now).FirstOrDefault();
                    if (competition == null)
                    {
                        Session["error"] = "This competition has finished!";
                        return Redirect("~/administrator/kinds/kindcompetition/" + idd);
                    }
                    else
                    {
                        if (form["submit_kind"] == null)
                        {
                            if (competition == null)
                            {
                                Session["error"] = "This competition had ended.";
                                return Redirect("~/administrator/kinds/kindcompetition/" + idd);
                            }
                            else
                            {
                                var listKind = competition.Kind.ToList();
                                var listKindOther = db.Kinds.ToList();
                                listKindOther = listKindOther.Except(listKind).ToList();
                                ViewBag.listKinds = listKindOther;
                                return View();
                            }
                        }
                        else
                        {
                            Strings stringModels = new Strings();
                            int[] IDKinds = stringModels.ListID(form["Kinds"]);
                            List<Kinds> listKinds = db.Kinds.Where(k => IDKinds.Contains(k.ID)).ToList();
                            listKinds.ForEach(delegate(Kinds kind)
                            {
                                competition.Kind.Add(kind);
                            });
                            db.SaveChanges();
                            return Redirect("~/administrator/kinds/addkindcompetition/" + idd);
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Add(FormCollection form)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
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
                    else if (!Validator.ISAlias(form["Alias"]))
                    {
                        stringBuilder.Append("<li>Competition alias unvalid</li>");
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        Kinds kind = new Kinds { Name = form["Name"], Alias = form["Alias"], DateUpdate = DateTime.Now, Description = form["Description"].Trim() };
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Edit(string id, FormCollection form)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
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
                        else if (form["Alias"].Trim() != kind.Alias)
                        {
                            try
                            {
                                string alias = form["Alias"].Trim();
                                Kinds kindOther = db.Kinds.Where(k => k.Alias == alias).First();
                                stringBuilder.Append("<li>This kind alias had been exists in database, try a different</li>");
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult Delete(string id)
        {
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
                try
                {
                    int idd = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    Kinds kind = db.Kinds.Include("Design").Where(k => k.ID == idd).First();
                    var listDesign = kind.Design.ToList();
                    listDesign.ForEach(delegate(Designs design)
                    {
                        design.Kind = null;
                    });
                    db.SaveChanges();
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
    }
}
