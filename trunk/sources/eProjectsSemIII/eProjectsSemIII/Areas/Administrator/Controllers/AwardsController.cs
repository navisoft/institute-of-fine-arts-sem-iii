using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class AwardsController : AuthenticationController
    {
        //
        // GET: /Administrator/Awards/

        public ActionResult Index()
        {
            base.Authentication();
            base.LoadMenu();
            return View();
        }

    }
}
