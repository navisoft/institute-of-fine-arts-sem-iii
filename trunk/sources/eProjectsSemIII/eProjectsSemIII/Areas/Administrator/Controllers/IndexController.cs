using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class IndexController
     * Admnistrator Page
     * Author: Le Dang Son
     * Date: 09/08/2012
     */
    public class IndexController : AuthenticationController
    {
        /**
         * Controller: Index
         * Action: Index
         * Load Administrator Index page
         * Author: Le Dang Son
         * Date: 09/08/2012
         */
        public ActionResult Index()
        {
            base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Home";
            var db = new FineArtContext();
            ViewBag.totalCompetition = db.Competitions.Count();
            ViewBag.totalDesign = db.Designs.Count();
            ViewBag.totalKind = db.Kinds.Count();
            ViewBag.totalExhibition = db.Exhibitions.Count();
            ViewBag.totalMember = db.Members.Count();

            ViewBag.newDesign = db.Designs.Include("Member").OrderBy(d => d.DatePost).Skip(0).Take(4);
            return View();
        }
    }
}
