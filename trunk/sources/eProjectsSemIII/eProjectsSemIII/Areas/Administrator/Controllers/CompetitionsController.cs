﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using System.Globalization;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{   
    /**
     * Class: CompetitionController
     * Manage Competitions
     * Author: Le Dang Son
     * Date: 08/08/2012
     */

    public class CompetitionsController : AuthenticationController
    {
        /**
         * Controller: Competition
         * Action: Index
         * List all competitions
         * Author: Le Dang Son
         * Date: 08/08/2012
         */
        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Competitions competitionsModels = new Competitions();
            decimal totalCompetition = competitionsModels.TotalCompetition();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalCompetition / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/competitions/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Competitions";
            return View(competitionsModels.ListCompetition((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

        public ActionResult CompetitionKind(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                Kinds kindsModels = new Kinds();
                kindsModels.ID = idd;
                kindsModels = kindsModels.GetNavigationWithID("Competition");
                ViewBag.Title += " Competition have " + kindsModels.Name + " Kind";
                return View(kindsModels.Competition.ToList());
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

            Competitions competitionsModels = new Competitions
            {
                Name = "Add new Competition",
                Alias = "add-new-competition",
                
            };
            return View();
        }
    }
}
