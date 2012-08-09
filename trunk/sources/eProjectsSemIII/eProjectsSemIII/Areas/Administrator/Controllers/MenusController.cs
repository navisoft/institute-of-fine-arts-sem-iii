using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: MenusController
     * Manage Menus System
     * Author: Le Dang Son
     * Date: 08/08/2012
     */
    public class MenusController : AuthenticationController
    {

        /**
         * Controller: Menus
         * Action: Index
         * List All menu system
         * Author: Le Dang Son
         * Date: 08/08/2012
         */
        public ActionResult Index()
        {
            //base.Authentication();
            base.LoadMenu();
            Menus menusModels = new Menus();
            List<Menus> listMenu = menusModels.ListMenu();
            listMenu.ForEach(delegate(Menus menu)
            {
                if (menu.Controller == "")
                {
                    menu.Controller = "Index";
                }
                if (menu.Action == "")
                {
                    menu.Action = "Index";
                }
                Strings stringsLibs = new Strings();
                menu.Controller = stringsLibs.Capacital(menu.Controller);
                menu.Action = stringsLibs.Capacital(menu.Action);
            });
            ViewBag.listMenu = listMenu;
            ViewBag.Title += " Menus";
            return View();
        }

    }
}
