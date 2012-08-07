using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * @class: AuthenticationController
     * @Authentication for administrator page
     * @author: Le Dang Son
     * @date: 06/08/2012
     */
    public class AuthenticationController : Controller
    {
        /**
         * @function: Authentication
         * @Check role by username
         * if is admin or manager or staff, continues else redirect to home page
         * @author: Le Dang Son
         * @date: 06/08/2012
         */
        public void Authentication()
        {

            if (Session["admin"] != null)
            {
                Members member = (Members)Session["admin"];
                if (member.Name != null && member.Name != "")
                {
                    ViewBag.Name = member.Name;
                    string controller = RouteData.Values["controller"].ToString();
                    string action = RouteData.Values["action"].ToString();
                    Roles role = new Roles();
                    role.ID = member.RoleID;
                    role = role.GetMenuRole();
                    ICollection<Menus> listMenu = role.Menu;
                    Response.Write
                    //foreach (Menus menu in listMenu)
                    //{
                    //    Response.Write(menu.Name);
                    //}
                }
                else
                {
                    Response.Redirect("/administrator/member/", true);
                }
            }
            else
            {
                Response.Redirect("/administrator/member/", true);
            }
        }
    }
}
