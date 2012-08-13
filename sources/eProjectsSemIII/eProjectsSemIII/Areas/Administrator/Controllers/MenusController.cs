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
        public ActionResult Index(string id)
        {
            //base.Authentication();
            base.LoadMenu();
            try
            {
                Menus menusModels = new Menus();
                List<Menus> listMenu;
                if (id != null && id != "")
                {
                    string[] arrID = id.Split('-');
                    Roles role = new Roles();
                    role.ID = Convert.ToInt16(arrID[1]);
                    role = role.GetRoleWithID();
                    listMenu = role.Menu.ToList();
                    ViewBag.Title += " Menus for "+role.Name;
                }
                else
                {
                    listMenu = menusModels.ListMenu();
                    ViewBag.Title += " Menus";
                } 
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
                    //Strings stringsLibs = new Strings();
                    //menu.Controller = stringsLibs.Capacital(menu.Controller);
                    //menu.Action = stringsLibs.Capacital(menu.Action);
                });
                ViewBag.listMenu = listMenu;
                return View();
            }
            catch
            {
                Session["admin"] = null;
                return Redirect("~/");
            }
        }
    }
}
