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
    public class ClassesController : AuthenticationController
    {
        //
        // GET: /Administrator/Classes/

        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Classes classesModels = new Classes();
            decimal totalClasses = classesModels.TotalClasses();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalClasses / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/classes/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Classes";
            return View(classesModels.ListClasses((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

    }
}
