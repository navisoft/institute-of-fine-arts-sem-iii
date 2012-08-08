using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;
using eProjectsSemIII.Areas.Administrator.Models;

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
                if (member.Name != null && member.Name != "" && member.RoleID < 4)
                {
                    ViewBag.Name = member.Name;
                    MenusAdmin menusModels = new MenusAdmin();
                    menusModels.Controller = RouteData.Values["controller"].ToString();
                    menusModels.Action = RouteData.Values["action"].ToString();
                    if (menusModels.CheckMenuOfRole(member.RoleID) == false)
                        Response.Redirect("/administrator/", true);
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
