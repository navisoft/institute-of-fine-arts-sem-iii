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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
        public ActionResult AwardCompetition(string id)
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
                    Competitions competitionsModels = new Competitions();
                    competitionsModels.ID = idd;
                    competitionsModels = competitionsModels.ListNavigation("Award");
                    ViewBag.Title += " Awards of " + competitionsModels.Name + " Competition";
                    ViewBag.competitionID = idd;
                    return View(competitionsModels.Award.ToList());
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

        public ActionResult AddAwardCompetition(string id, FormCollection form)
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
                    int competitionID = Convert.ToInt16(id);
                    var db = new FineArtContext();
                    var competition = db.Competitions
                        .Include("Award")
                        .Where(c => c.ID == competitionID && c.DeadlineDate > DateTime.Now)
                        .FirstOrDefault();
                    ViewBag.competitionID = competitionID;
                    if (competition == null)
                    {
                        Session["error"] = "This competition has finished.";
                        return Redirect("~/administrator/awards/awardcompetition/" + competitionID);
                    }
                    else
                    {
                        int maxLevel = 0;
                        try
                        {
                            maxLevel = competition.Award.Max(a => a.Level);
                        }
                        catch
                        {
                            maxLevel = 0;
                        }
                        List<Awards> listAwards = db.Awards.Where(a => a.Level > maxLevel).ToList();
                        ViewBag.listAwards = listAwards;
                        if (form["submit_award"] != null)
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            stringBuilder.Append("<ul>");
                            int[] IDAwards = new Strings().ListID(form["Awards"]);
                            List<Awards> listAward = db.Awards.Where(a => IDAwards.Contains(a.ID)).ToList();
                            int j = listAward.Count;
                            int i = 0;
                            int[] Levels = new int[j];
                            for (i = 0; i < j; i++)
                            {
                                Levels[i] = listAward[i].Level;
                            }
                            for (i = maxLevel + 1; i <= j + maxLevel; i++)
                            {
                                if (!Levels.Contains(i))
                                {
                                    stringBuilder.Append("<li>Please choose award for competition. Level of awards not duplicate</li>");
                                    break;
                                }
                            }
                            if (stringBuilder.ToString() == "<ul>")
                            {
                                Response.Write("OK");
                                foreach (Awards award in listAward)
                                {
                                    competition.Award.Add(award);
                                }
                                db.SaveChanges();
                                return Redirect("~/administrator/awards/addawardcompetition/" + competitionID);
                            }
                            else
                            {
                                stringBuilder.Append("</ul>");
                                ViewBag.error = stringBuilder.ToString();
                            }

                        }
                        return View();
                    }
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
        public ActionResult RemoveAwardCompetition(string id, string param)
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
                    int awardID = Convert.ToInt16(id);
                    int competitionID = Convert.ToInt16(param);
                    var db = new FineArtContext();
                    var competition = db.Competitions.Include("Award").Where(c => c.ID == competitionID).First();
                    var award = competition.Award.Where(a => a.ID == awardID).First();
                    competition.Award.Remove(award);
                    db.SaveChanges();
                    return Redirect("~/administrator/awards/awardcompetition/" + competitionID);
                }
                catch (Exception e)
                {
                    Response.Write(e.Message);
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
                if (form["submit_award"] != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<ul>");
                    Strings stringsLibs = new Strings();
                    if (form["Name"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition name</li>");
                    }
                    if (form["Level"] == "-1")
                    {
                        stringBuilder.Append("<li>Please choose level for this award</li>");
                    }
                    if (form["Description"].Trim() == "")
                    {
                        stringBuilder.Append("<li>Please type competition description</li>");
                    }
                    if (stringBuilder.ToString() == "<ul>")
                    {
                        Awards award = new Awards
                        {
                            Name = form["Name"],
                            DateUpdate = DateTime.Now,
                            Description = form["Description"].Trim(),
                            Level = Convert.ToInt16(form["Level"])
                        };
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
                ViewBag.maxLevel = db.Awards.Max(a => a.Level);
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
                base.LoadMenu();
                var db = new FineArtContext();
                try
                {
                    int idd = Convert.ToInt16(id);
                    Awards award = db.Awards.Where(a => a.ID == idd).FirstOrDefault();
                    if (form["submit_award"] == null)
                    {
                        form["Name"] = award.Name;
                        form["Description"] = award.Description;
                        form["Level"] = award.Level.ToString();
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
                    ViewBag.maxLevel = db.Awards.Max(a => a.Level);
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }
    }
}
