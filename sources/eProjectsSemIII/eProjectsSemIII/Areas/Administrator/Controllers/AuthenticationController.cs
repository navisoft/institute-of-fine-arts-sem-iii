﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * Class: AuthenticationController
     * Authentication for administrator page
     * Author: Le Dang Son
     * Date: 06/08/2012
     */
    public class AuthenticationController : Controller
    {
        /**
         * Function: Authentication
         * Check role by username
         * If is admin or manager or staff, continues else redirect to home page
         * Author: Le Dang Son
         * Date: 06/08/2012
         */
        public void Authentication()
        {
            if (Session["admin"] != null)
            {
                Members member = (Members)Session["admin"];
                if (member.Name != null && member.Name != "" && member.Role.ID < 4)
                {
                    ViewBag.Name = member.Name;
                    Menus menusModels = new Menus();
                    menusModels.Controller = RouteData.Values["controller"].ToString().ToLower();
                    menusModels.Action = RouteData.Values["action"].ToString().ToLower();

                    if (menusModels.CheckMenuOfRole(member.Role.ID) == false)
                    {
                        Session["admin"] = null;
                        Response.Redirect("/", true);
                    }
                }
                else
                {
                    Session["admin"] = null;
                    Response.Redirect("/", true);
                }
            }
            else
            {
                Response.Redirect("/administrator/members/login", true);
            }
        }

        public void LoadMenu()
        {
            //if (Session["admin"] != null)
            //{
                //Members member = (Members)Session["admin"];
                Roles rolesModels = new Roles();
                rolesModels.ID = 1;//member.RoleID;
                rolesModels = rolesModels.GetRoleWithID();
                ViewBag.Title = rolesModels.Name + " Page:";
                ICollection<Menus> listMenus = rolesModels.Menu.Where(m=>m.Display == true).ToList();
                //var listParentMenu = listMenu.Where(m => m.ParentID == -1);
                //foreach (Menus parentMenu in listParentMenu)
                //{
                //    var listChildMenu = listMenu.Where(m => m.ParentID == parentMenu.ID);
                //    foreach (Menus childMenu in listChildMenu)
                //    {
                //        Response.Write(childMenu.Name);
                //    }
                //}
                ViewBag.listMenuMain = listMenus;
            //}
        }
    }
}
