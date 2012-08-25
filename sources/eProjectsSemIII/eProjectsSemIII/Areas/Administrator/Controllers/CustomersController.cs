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
            int admin = base.Authentication();
            if (admin == 0)
            {
                return Redirect("~/member/logout");
            }
            else if (admin == 1)
            {
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
            else
            {
                Session["errorContorllerAction"] = true;
                return Redirect("~/administrator");
            }
        }

    }
}
