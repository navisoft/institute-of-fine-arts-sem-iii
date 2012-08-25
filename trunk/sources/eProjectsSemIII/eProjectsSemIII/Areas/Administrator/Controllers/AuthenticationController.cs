using System;
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
        public int Authentication()
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
                    var db = new FineArtContext();
                    var query = db.Menus.Include("Role")
                        .Where(m => m.Controller == ((menusModels.Controller == "index") ? "" : menusModels.Controller)
                            && m.Action == ((menusModels.Action == "index") ? "" : menusModels.Action))
                            .FirstOrDefault();
                    var role = query.Role.Where(r => r.ID == member.Role.ID).FirstOrDefault();
                    if (role == null)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public void LoadMenu()
        {
            if (Session["admin"] != null)
            {
                Members member = (Members)Session["admin"];
                Roles rolesModels = new Roles();
                rolesModels.ID = member.Role.ID;
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
            }
        }
    }
}
