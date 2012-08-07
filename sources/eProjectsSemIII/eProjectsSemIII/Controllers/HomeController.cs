using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Controllers
{
    public class HomeController : Controller
    {
        /**
         * Method: Index
         * Create database demo using Entity Framework
         * Author: Le Dang Son
         * Date: 04/08/2012
         */
        public ActionResult Index()
        {
            //Competitions competitionModels = new Competitions();
            //List<CompetitionModels> listCompetition = competitionModels.getAllCompetition();
            //foreach (CompetitionModels competition in listCompetition)
            //{
            //    Response.Write(competition.Name);
            //}
            //var com = new Competitions { Name = "OKKKKKKKKKKKKKKKKKKKKKKK", StartDate = "121132" };
            //var db = new FineArtContext();
            //db.Competitions.Add(com);
            //db.SaveChanges();
            using (var db = new FineArtContext())
            {
                db.Members.ToList();
            }
            //FinelArtInitializer fine = new FinelArtInitializer();
            //FineArtContext context = new FineArtContext();
            //fine.initData(context);
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
