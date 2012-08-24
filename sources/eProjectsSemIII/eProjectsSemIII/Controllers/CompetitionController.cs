using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;

namespace eProjectsSemIII.Controllers
{
    public class CompetitionController : AuthenticationController
    {
        public ActionResult Index(string id)
        {
            base.Authentication();
            var db = new FineArtContext();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            decimal totalCompetition = db.Competitions.Count();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalCompetition / totalRecord));
            if (currentPage > totalPage)
            {
                currentPage = totalPage;
            }
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            var competition = db.Competitions
                .OrderBy(o => o.StartDate)
                .Skip((int)((currentPage - 1) * totalRecord))
                .Take((int)totalRecord)
                .ToList();
            ViewBag.pagingString = Paging.GenerateLinkPaging("competition/index");
            return View(competition);
        }
        public ActionResult Detail(string id)
        {
            base.Authentication();
            if (id != null && Validator.ISAlias(id))
            {
                var db = new FineArtContext();
                var upcomming = db.Competitions.Include("Condition").Include("Award").Include("Staffs").Include("Design").Single(g => g.Alias == id);
                ViewBag.Title = "Competition: " + upcomming.Name;
                return View(upcomming);
            }
            else
            {
                return Redirect("~/error");
            }
        }

    }
}
