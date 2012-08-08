using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class RolesController : AuthenticationController
    {
        //
        // GET: /Administrator/Roles/

        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Roles";
            return View();
        }

    }
}
