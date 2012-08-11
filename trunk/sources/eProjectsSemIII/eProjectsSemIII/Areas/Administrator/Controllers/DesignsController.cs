using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;
using eProjectsSemIII.Configs;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    public class DesignsController : AuthenticationController
    {
        //
        // GET: /Administrator/Designs/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Designs designsModels = new Designs();
            decimal totalDesign= designsModels.TotalDesign();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalDesign / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/designs/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Designs";
            return View(designsModels.ListDesign((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

    }
}
