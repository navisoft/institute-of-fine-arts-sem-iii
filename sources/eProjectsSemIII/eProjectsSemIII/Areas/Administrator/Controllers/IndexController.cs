﻿using System;
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
            //base.Authentication();
            base.LoadMenu();
            ViewBag.Title += " Home";
            return View();
        }
        public ActionResult Roles()
        {
            base.Authentication();
            return View();
        }
    }
}
