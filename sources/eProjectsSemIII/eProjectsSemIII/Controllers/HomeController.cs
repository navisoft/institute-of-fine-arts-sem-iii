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

        // list upcomming with items
        public ActionResult Index()
        {

            base.Authentication();
            
            if (Session["user-loged"] != null && Session["user-loged"].ToString() != "")
            {
                var upcomming = db.Competitions.Where(s => s.StartDate > DateTime.Now).ToList();
                ViewBag.upcomming = upcomming;

                var oncomming = db.Competitions.Include("Design")
                                  .Where(p => p.StartDate < DateTime.Now && p.EndDate >= DateTime.Now)
                                  .ToList();
                ViewBag.oncomming = oncomming;

                var competition = db.Competitions.Include("Award")
                    .Where(c => c.EndDate < DateTime.Now)
                    .OrderByDescending(c => c.EndDate)
                    .Take(1).First();
                var studentaward = db.Marks
                   .Join(db.Members, mark => mark.Design.Member.ID, member => member.ID, (mark, member) => new { Member = member, Mark = mark })
                   .Where(a => a.Mark.Design.Competition.ID == competition.ID)
                   .GroupBy(b => b.Mark.Design)
                   .OrderByDescending(c => c.Average(z => z.Mark.Mark))
                   .ThenBy(c => c.Key.DatePost)
                   .Take(competition.Award.Count)
                   .ToList();
                List<MemberAward> listMemberAward = new List<MemberAward>();
                MemberAward memberAward;
                foreach (var item in studentaward)
                {
                    memberAward = new MemberAward();
                    memberAward.ID = item.Key.Member.ID;
                    memberAward.Name = item.Key.Member.Name;
                    memberAward.Image = item.Key.Member.Images;
                    memberAward.Mark = item.Average(m => m.Mark.Mark).ToString();
                    memberAward.Design = item.Key;
                    listMemberAward.Add(memberAward);
                }
                ViewBag.listMemberAward = listMemberAward;
                return View(upcomming);
            }
            else
            {
                return Redirect("~/member");
            }
        }
        // list kind as menu left

        [ChildActionOnly]
        public virtual ActionResult Kind()
        {
            var kinds = db.Kinds.ToList();
            ViewBag.kind = kinds;
            return PartialView();
        }
        // profile

        [ChildActionOnly]
        public virtual ActionResult Profile()
        {
            try
            {
                string username = Session["user-loged"].ToString();
                var db = new FineArtContext();
                var member = db.Members.Include("Role").Where(m => m.Username == username).First();
                Roles role = member.Role;
                var menus = db.Menus.Include("Role").Where(m => m.Role.Any(r => r.ID == member.Role.ID)).ToList();
                if (menus.Count > 0)
                {
                    ViewBag.gotoAdmin = true;
                }
                return PartialView(member);
            }
            catch
            {
                return Redirect("~/member");
            }
        }

        public class MemberAward
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
            public string Mark { get; set; }
            public string Awrad { get; set; }
            public string Competition { get; set; }
            public Designs Design { get; set; }
        }
    }
}
