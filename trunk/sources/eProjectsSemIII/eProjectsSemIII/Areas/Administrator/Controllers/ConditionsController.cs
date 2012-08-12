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
                return Redirect("~/");
            }
        }
    }
}
