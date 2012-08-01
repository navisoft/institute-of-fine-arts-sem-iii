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
        public ActionResult Index()
        {
            CompetitionModels competitionModels = new CompetitionModels();
            List<CompetitionModels> listCompetition = competitionModels.getAllCompetition();
            foreach (CompetitionModels competition in listCompetition)
            {
                Response.Write(competition.Name);
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
