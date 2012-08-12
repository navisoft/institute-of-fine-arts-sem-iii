using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;

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
    }
}
