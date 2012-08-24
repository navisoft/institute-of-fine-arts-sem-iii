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
    public class CustomersController : AuthenticationController
    {
        //
        // GET: /Administrator/Customers/

        public ActionResult Index(string id)
        {
            base.Authentication();
            base.LoadMenu();
            int currentPage = Paging.GetPage(id);
            decimal totalRecord = GlobalInfo.NumberRecordInPage;
            Customers customersModels = new Customers();
            decimal totalCustomer = customersModels.TotalCustomer();
            int totalPage = (int)Math.Ceiling(Convert.ToDecimal(totalCustomer / totalRecord));
            Paging.numPage = totalPage;
            Paging.numLinkDisplay = GlobalInfo.NumLinkPagingDisplay;
            Paging.currentPage = currentPage;
            string url = "administrator/customers/index";
            ViewBag.pagingString = Paging.GenerateLinkPaging(url);
            ViewBag.Title += " Customers";
            return View(customersModels.ListCustomers((int)((currentPage - 1) * totalRecord), (int)totalRecord));
        }

    }
}
