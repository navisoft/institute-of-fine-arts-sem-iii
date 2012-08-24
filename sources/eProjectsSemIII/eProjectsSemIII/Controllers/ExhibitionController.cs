using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;

namespace eProjectsSemIII.Controllers
{
    public class ExhibitionController : AuthenticationController
    {
        //
        // GET: /Exhibition/

        public ActionResult Index(string id)
        {
            base.Authentication();
            var db = new FineArtContext();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            decimal totalExhibition = db.Exhibitions.Count();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalExhibition / totalRecord));
            if (currentPage > totalPage)
            {
                currentPage = totalPage;
            }
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            var exhibition = db.Exhibitions
                .OrderBy(o => o.StartDate)
                .Skip((int)((currentPage - 1) * totalRecord))
                .Take((int)totalRecord)
                .ToList();
            ViewBag.pagingString = Paging.GenerateLinkPaging("exhibition/index");
            return View(exhibition);
        }

        public ActionResult Detail(string id)
        {
            base.Authentication();
            if (id != null && Validator.ISAlias(id))
            {
                var db = new FineArtContext();
                var exhibition = db.Exhibitions.Where(e => e.Alias == id).First();
                return View(exhibition);
            }
            else
            {
                return Redirect("~/");
            }
        }

    }
}
