using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: MenusController
     * Manage Menus System
     * Author: Le Dang Son
     * Date: 08/08/2012
     */
    public class MenusController : AuthenticationController
    {

        /**
         * Controller: Menus
         * Action: Index
         * List All menu system
         * Author: Le Dang Son
         * Date: 08/08/2012
         */
        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Menus";
            return View();
        }

    }
}
