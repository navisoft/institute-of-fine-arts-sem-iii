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
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Designs exhibitionsModels = new Designs();
            decimal totalDesign= exhibitionsModels.TotalDesign();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/designs/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Designs";
            return View(exhibitionsModels.ListDesign((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult DesignCompetition(string id)
        {
            //base.Authentication();
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
                return Redirect("~/");
            }
        }

        public ActionResult DesignKind(string id)
        {
            //base.Authentication();
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
                return Redirect("~/");
            }
        }

        public ActionResult DesignExhibition(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Exhibitions exhibitionsModels = new Exhibitions();
                exhibitionsModels.ID = idd;
                exhibitionsModels = exhibitionsModels.GetNavigationWithID("Designs");
                ViewBag.Title += " Designs of " + exhibitionsModels.Name + " Exhibition";
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
                return Redirect("~/");
            }
        }

        public ActionResult DesignMember(string id)
        {
            //base.Authentication();
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
                return Redirect("~/");
            }
        }
    }
}
