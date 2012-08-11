using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Home";
            return View();
        }
    }
}
