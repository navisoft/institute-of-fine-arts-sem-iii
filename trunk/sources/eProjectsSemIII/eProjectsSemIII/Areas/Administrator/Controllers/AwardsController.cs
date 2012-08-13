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
                return Redirect("~/");
            }
        }
    }
}
