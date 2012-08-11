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
    public class ExhibitionsController : AuthenticationController
    {
        //
        // GET: /Administrator/Exhibitions/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Exhibitions exhibitionsModels = new Exhibitions();
            decimal totalExhibition = exhibitionsModels.TotalExhibition();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalExhibition / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/exhibitions/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Exhibitions";
            return View(exhibitionsModels.ListExhibition((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

    }
}
