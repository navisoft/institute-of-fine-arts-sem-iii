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
            using (var db = new FineArtContext())
            {
                var competition = from c in db.Competitions
                                  select c;
                foreach (var com in competition)
                {

                }
            }
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
