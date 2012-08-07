using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class CompetitionController : Controller
    {
        //
        // GET: /Administrator/Competition/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            Response.Write(id);
            return View();
        }
    }
}
