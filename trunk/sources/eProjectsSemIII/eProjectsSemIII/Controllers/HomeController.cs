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
    public class HomeController : AuthenticationController
    {

        private FineArtContext db = new FineArtContext();
        const int pagsize=3;

        // list upcomming with items
        public ActionResult Index()
        {
            base.Authentication();
            var db = new FineArtContext();
            var query2 = db.Marks
                .Join(db.Members,mark=>mark.Design.Member.ID,member=>member.ID,(mark,member)=>new {Member = member,Mark=mark})
                .Join(db.Competitions,mark1=>mark1.Mark.Design.Competition.ID,competition=>competition.ID,(mark1,competition)=>new{Competition=competition,Mark=mark1})
                .Where(a=>a.Mark.Mark.Design.Competition.ID == 1)
                .GroupBy(b=>b.Mark.Mark.Design)
                .OrderByDescending(c=>c.Average(z=>z.Mark.Mark.Mark))
                .ToList();


            foreach (var item in query2)
            {
                Response.Write(item.Key.Name + "<br>");
                Response.Write(item.Key.Member.Name+"<br>");
                Response.Write(item.Average(a => a.Mark.Mark.Mark) + "<br>");
            }

            //.Where(m => m.Design.Competition.ID == 1)
            //.GroupBy(m => m.Design)
            //.OrderBy(m => m.Average(z => z.Mark))
            //var query = from m in db.Marks
            //            where m.Design.Competition.ID == 1
            //            group m by m.Design into gr
            //            orderby gr.Average(z => z.Mark)
            //            select new { Id = gr.Key, avgMark = gr.Average(z => z.Mark) };
            //foreach (var item in query)
            //{
            //    Response.Write(item.Id + "<br>");
            //    Response.Write(item.avgMark + "<br>");
            //}
            var upcomming = db.Competitions.Where(s=>s.StartDate>DateTime.Now).ToList();
            ViewBag.upcomming = upcomming;
            return View(upcomming);
           

        }

        // detail upcomming
        public ActionResult detail_upcomming(string id)
        {

            var upcomming = db.Competitions.Include("Condition").Include("Award").Include("Staffs").Include("Design").Single(g => g.Alias == id);
            return View(upcomming);
        }


        // list oncomming with take 4 items
        public ActionResult Oncomming()
        {
            var oncomming = db.Competitions
                              .Where(p => p.StartDate < DateTime.Now && p.EndDate >= DateTime.Now)
                              .Take(4)
                              .ToList();
            
            ViewBag.oncomming = oncomming;
           return PartialView();
        }


        //paging competition
        public ActionResult listAllCompetition(int page = 1)
        {
            var competition = db.Competitions
                              .OrderBy(p => p.ID)
                              .Skip((page - 1) * pagsize)
                              .Take(pagsize)
                              .ToList();
            ViewBag.currentpage = page;
            ViewBag.PageSize = pagsize;
            ViewBag.TotalPage = Math.Ceiling((double)db.Competitions.Count() / pagsize);

            
            return View(competition);
        }

        // list all design 
        public ActionResult ListAllDesign(int page=1)
        {
            var design = db.Designs.Include("Member").Include("Kind").Include("Competition")
                              .OrderBy(p => p.ID)
                              .Skip((page - 1) * pagsize)
                              .Take(pagsize)
                              .ToList();
            ViewBag.currentpage = page;
            ViewBag.PageSize = pagsize;
            ViewBag.TotalPage = Math.Ceiling((double)db.Designs.Count() / pagsize);
            return View(design);
        }

        // list all exhibition 
        public ActionResult ListAllExhibition(int page = 1)
        {
            var exhibition = db.Exhibitions.Include("Designs")
                              .OrderBy(p => p.ID)
                              .Skip((page - 1) * pagsize)
                              .Take(pagsize)
                              .ToList();
            ViewBag.currentpage = page;
            ViewBag.PageSize = pagsize;
            ViewBag.TotalPage = Math.Ceiling((double)db.Exhibitions.Count() / pagsize);
            return View(exhibition);
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

        public virtual ActionResult Browse(int id)
        {
            // Retrieve Design and its Associated Kind from database 
            var design = db.Kinds.Include("Design").Single(g => g.ID == id);
            return View(design);


        }

        // detail of design when click a single design
        public virtual ActionResult Details(int id)
        {
            var design = db.Designs.Include("Member").Include("Competition").Single(g => g.ID == id);
            //var album = db.Designs.Find(designid);
            return View(design);
        }

        // list all student which had a ward of competition 
      
       
        public ActionResult list_student()
        {
            //var designs = db.Designs.Include("Award").Include("Member")
            //                        .Where(d => d.Award.ID != null)
            //                        .ToList();
            //ViewBag.designs = designs;
            Competitions competition = new Competitions();
            competition.ID = 1;
            //var marks = db.Marks.Where(m => m.Competition == competition).GroupBy(m => m.Design.ID).ToList();
            //foreach (Marks mark in marks)
            //{
            //    Response.Write(mark.Mark);
            //}
            //var query = from m in db.Marks
            //            where m.Competition.ID == 1
            //            group m by m.Design into gr
            //            select new { Id = gr.Key, avgMark = gr.Average(z => z.Mark) };
            //foreach (var item in query)
            //{
            //    Response.Write(item.avgMark);
            //}
            return PartialView();
        }
    }
}
