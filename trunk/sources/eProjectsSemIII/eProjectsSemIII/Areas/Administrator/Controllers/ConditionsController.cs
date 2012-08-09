using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class ConditionsController : AuthenticationController
    {
        //
        // GET: /Administrator/Conditions/

        public ActionResult Index()
        {
            base.Authentication();
            base.LoadMenu();
            return View();
        }

    }
}
