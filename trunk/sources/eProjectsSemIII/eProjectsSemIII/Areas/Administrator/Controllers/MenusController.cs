using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class MenusController : AuthenticationController
    {
        //
        // GET: /Administrator/Menus/

        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Menus";
            return View();
        }

    }
}
