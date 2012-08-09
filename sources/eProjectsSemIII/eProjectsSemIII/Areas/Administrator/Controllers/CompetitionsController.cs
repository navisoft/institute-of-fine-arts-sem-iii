using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Competitions";
            return View();
        }
    }
}
