using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class KindsController : AuthenticationController
    {
        //
        // GET: /Administrator/Kinds/

        public ActionResult Index()
        {
            base.Authentication();
            return View();
        }

    }
}
