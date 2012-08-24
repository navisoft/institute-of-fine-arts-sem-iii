using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Controllers
{
    public class ErrorController : AuthenticationController
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            base.Authentication();
            return View();
        }

    }
}
