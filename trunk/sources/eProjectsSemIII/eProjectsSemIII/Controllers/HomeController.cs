using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using System.Security.Cryptography;
using System.Text;

namespace eProjectsSemIII.Controllers
{
    public class HomeController : Controller
    {

        private FineArtContext db = new FineArtContext();
        public ActionResult Index()
        {
            var upcomming = db.Competitions.ToList();

            return View(upcomming);
        }

        // list kind as menu left

        [ChildActionOnly]
        public virtual ActionResult Kind()
        {
            var kinds = db.Kinds.ToList();
            ViewBag.kind = kinds;
            return PartialView();

        }

        //list design follow design

        public virtual ActionResult Browse(int kinid)
        {
            // Retrieve Design and its Associated Kind from database 
            var design = db.Kinds.Include("Design").Single(g => g.ID == kinid);
            return View(design);


        }

        //// detail of design when click a single design
        //public virtual ActionResult Details(int id)
        //{
        //    var album = db.Designs.Find(id);
        //    return View(album);
        //}
    }
}
