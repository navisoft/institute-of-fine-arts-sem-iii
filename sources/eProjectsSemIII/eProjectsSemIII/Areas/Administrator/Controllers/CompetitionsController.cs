using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eProjectsSemIII.Configs;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Models;

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

            var db = new FineArtContext();
            int[] IDCondition = { 1, 2, 3 };
            ICollection<Conditions> listCondition = db.Conditions.Where(c => IDCondition.Contains(c.ID)).ToList();
            int[] IDAward = { 1, 2, 3 };
            ICollection<Awards> listAward = db.Awards.Where(a => IDAward.Contains(a.ID)).ToList();
            int[] IDKind = { 1, 2, 3 };
            ICollection<Kinds> listKind = db.Kinds.Where(k => IDKind.Contains(k.ID)).ToList();
            foreach (Kinds aw in listKind)
            {
                Response.Write(aw.Name+"<br>");
            }
            Competitions competitionsModels = new Competitions
            {
                Name = "Add new Competition",
                Alias = "add-new-competition",
                Images = "add-new-competition.jpg",
                Condition = listCondition,
                Award = listAward,
                Kind = listKind,
                StartDate = DateTime.Now,
                DeadlineDate = DateTime.Parse("26/08/2012"),
                EndDate = DateTime.Parse("16/09/2012"),
                Summary = "Summary of Add new Competition"
            };
            db.Competitions.Add(competitionsModels);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(string id)
        {
            //base.Authentication();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                var competitionsModels = db.Competitions.Include("Design").Where(c => c.ID == idd).FirstOrDefault();
                var listDesign = competitionsModels.Design.ToList();
                listDesign.ForEach(delegate(Designs ds)
                {
                    var listMark = db.Marks.Where(m => m.Design.ID == ds.ID).ToList();
                    listMark.ForEach(delegate(Marks mk)
                    {
                        db.Marks.Remove(mk);
                    });
                    var listCustomer = db.Customers.Where(c => c.Design.ID == ds.ID).ToList();
                    listCustomer.ForEach(delegate(Customers cus)
                    {
                        db.Customers.Remove(cus);
                    });
                    db.Designs.Remove(ds);
                });
                db.Competitions.Remove(competitionsModels);
                db.SaveChanges();
                return Redirect("~/administrator/competitions/");
            }
            catch
            {
                return Redirect("~/");
            }

        }
        public ActionResult Edit(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                int idd = Convert.ToInt16(id);
                var db = new FineArtContext();
                Competitions competitonsModels;
                competitonsModels = db.Competitions.Where(c => c.ID == idd).FirstOrDefault();
                competitonsModels.Name = "New Name2";
                db.SaveChanges();
                return Redirect("~/administrator/competitions/");
            }
            catch
            {
                return Redirect("~/");
            }
        }
    }
}
