using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class IndexController : AuthenticationController
    {
        //
        // GET: /Administrator/Home/

        public ActionResult Index()
        {
            base.Authentication();
            return View();
        }
        public ActionResult Detail()
        {
            base.Authentication();
            return View();
        }
        public ActionResult Roles()
        {
            base.Authentication();
            return View();
        }
    }
}
