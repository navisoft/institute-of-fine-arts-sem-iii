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
        public ActionResult Index()
        {
            //CompetitionModels competitionModels = new CompetitionModels();
            //List<CompetitionModels> listCompetition = competitionModels.getAllCompetition();
            //foreach (CompetitionModels competition in listCompetition)
            //{
            //    Response.Write(competition.Name);
            //}
            //var com = new Competitions { Name = "OKKKKKKKKKKKKKKKKKKKKKKK", StartDate = "121132" };
            //var db = new FineArtContext();
            //db.Competitions.Add(com);
            //db.SaveChanges();
            //var com = new CompetitionModels { Name = "Competition First 1", StartDate = "12/12/1212" };
            //var db = new FineArtContext();
            //db.Competitions.Add(com);
            //db.SaveChanges();
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
