using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class DesignsController : AuthenticationController
    {
        //
        // GET: /Administrator/Designs/

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
                Designs exhibitionsModels = new Designs();
                decimal totalDesign = exhibitionsModels.TotalDesign();
                int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
                Paging.numPage = totalPage;
                Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
                Paging.currentPage = currentPage;
                string url = "administrator/designs/index";
                ViewBag.pagingString = Paging.GenerateLinkPaging(url);
                ViewBag.Title += " Designs";
                Session["back-url"] = "~/administrator/designs/";
                return View(exhibitionsModels.ListDesign((int)((currentPage - 1) * totalRecord), (int)totalRecord));
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult DesignCompetition(string id)
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
                    competitionsModels = competitionsModels.ListNavigation("Design");
                    ViewBag.Title += " Designs of " + competitionsModels.Name + " Competition";
                    List<Designs> listDesign = competitionsModels.Design.ToList();
                    List<Designs> listDesignNew = new List<Designs>();
                    listDesign.ForEach(delegate(Designs design)
                    {
                        design = design.GetDesignByID();
                        listDesignNew.Add(design);
                    });
                    return View(listDesignNew);
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

        public ActionResult DesignKind(string id)
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
                    Kinds kindsModels = new Kinds();
                    kindsModels.ID = idd;
                    kindsModels = kindsModels.GetNavigationWithID("Design");
                    ViewBag.Title += " Designs of " + kindsModels.Name + " Competition";
                    List<Designs> listDesign = kindsModels.Design.ToList();
                    List<Designs> listDesignNew = new List<Designs>();
                    listDesign.ForEach(delegate(Designs design)
                    {
                        design = design.GetDesignByID();
                        listDesignNew.Add(design);
                    });
                    return View(listDesignNew);
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

        public ActionResult DesignExhibition(string id)
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
                    Exhibitions exhibitionsModels = new Exhibitions();
                    exhibitionsModels.ID = idd;
                    exhibitionsModels = exhibitionsModels.GetNavigationWithID("Designs");
                    ViewBag.Title += " Designs of " + exhibitionsModels.Name + " Exhibition";
                    ViewBag.exhibitionID = idd;
                    List<Designs> listDesign = exhibitionsModels.Designs.ToList();
                    List<Designs> listDesignNew = new List<Designs>();
                    listDesign.ForEach(delegate(Designs design)
                    {
                        design = design.GetDesignByID();
                        listDesignNew.Add(design);
                    });
                    return View(listDesignNew);
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

        public ActionResult AddDesignExhibition(string id, string param, FormCollection form)
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
                    ViewBag.exhibitionID = idd;
                    var db = new FineArtContext();
                    var exhibition = db.Exhibitions.Include("Designs").Where(e => e.ID == idd && e.EndDate > DateTime.Now).FirstOrDefault();
                    if (exhibition == null)
                    {
                        Session["error"] = "This exhibition had ended.";
                        return Redirect("~/administrator/designs/designexhibition/" + idd);
                    }
                    else
                    {
                        if (form["submit_design_exhibition"] == null)
                        {
                            int currentPage = Paging.GetPage(param);
                            decimal totalRecord = GlobalInfo.NumberRecordInPage;
                            var designs = db.Designs
                                .Include("Member")
                                .Include("Kind")
                                .Include("Competition").ToList();
                            designs = designs.Except(exhibition.Designs).ToList();
                            decimal totalDesign = designs.Count;
                            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
                            Paging.numPage = totalPage;
                            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
                            Paging.currentPage = currentPage;
                            string url = "administrator/designs/adddesignexhibition/" + idd;
                            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
                            ViewBag.Title += " Add design to exhibition";
                            var listDesigns = designs
                                .OrderBy(d => d.ID).Skip((int)((currentPage - 1) * totalRecord)).Take((int)totalRecord).ToList();
                            return View(listDesigns);
                        }
                        else
                        {
                            Strings stringModels = new Strings();
                            int[] IDDesigns = stringModels.ListID(form["Design"]);
                            var designs = db.Designs.Where(d => IDDesigns.Contains(d.ID)).ToList();
                            designs.ForEach(delegate(Designs design)
                            {
                                exhibition.Designs.Add(design);
                            });
                            db.SaveChanges();
                            return Redirect("~/administrator/designs/adddesignexhibition/" + idd);
                        }
                    }
                }
                catch
                {
                    Response.Write("OKOKO");
                    return null;
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult RemoveDesignExhibition(string id, string param)
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
                    int designID = Convert.ToInt16(id);
                    int exhibitionID = Convert.ToInt16(param);
                    var db = new FineArtContext();
                    var exhibition = db.Exhibitions.Include("Designs").Where(e => e.ID == exhibitionID).First();
                    var design = exhibition.Designs.Where(d => d.ID == designID).First();
                    exhibition.Designs.Remove(design);
                    db.SaveChanges();
                    return Redirect("~/administrator/designs/designexhibition/" + exhibitionID);
                }
                catch
                {
                    Session["admin"] = null;
                    return Redirect("~/member/logout");
                }
            }
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

        public ActionResult DesignMember(string id)
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
                    Members membersModels = new Members();
                    membersModels.ID = idd;
                    membersModels = membersModels.GetMemberWithID();
                    ViewBag.Title += " Designs of " + membersModels.Name + " Member";
                    List<Designs> listDesign = membersModels.Design.ToList();
                    List<Designs> listDesignNew = new List<Designs>();
                    listDesign.ForEach(delegate(Designs design)
                    {
                        design = design.GetDesignByID();
                        listDesignNew.Add(design);
                    });
                    return View(listDesignNew);
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

        public RedirectResult Delete(string id)
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
                    Designs design = db.Designs.Where(d => d.ID == idd).First();
                    List<Marks> listMark = db.Marks.Where(m => m.Design.ID == design.ID).ToList();
                    listMark.ForEach(delegate(Marks mark)
                    {
                        db.Marks.Remove(mark);
                    });
                    List<Customers> listCustomer = db.Customers.Where(c => c.Design.ID == design.ID).ToList();
                    listCustomer.ForEach(delegate(Customers customer)
                    {
                        customer.Design = null;
                    });

                    db.SaveChanges();
                    db.Designs.Remove(design);
                    db.SaveChanges();
                    return Redirect("~/administrator/designs");
                }
                catch
                {
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
