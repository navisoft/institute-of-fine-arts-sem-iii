using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: RolesController
     * Manage Roles System
     * Author: Le Dang Son
     * Date: 08/08/2012
     */
    public class RolesController : AuthenticationController
    {
        /**
         * Controller: Roles
         * Action: Index
         * List all roles system
         * Author: Le Dang Son
         * Date: 08/08/2012
         */

        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Roles";
            return View();
        }

    }
}
