using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using System.Security.Cryptography;
using System.Text;

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
                var competition = new Competitions { Name = "Competition First 1", StartDate = "04/08/2012", EndDate = "04/09/2012" };
                db.Competitions.Add(competition);
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
