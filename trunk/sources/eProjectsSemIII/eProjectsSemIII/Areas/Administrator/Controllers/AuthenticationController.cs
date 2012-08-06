using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if (Session["admin"] != null && (string)Session["admin"] != "")
            {

            }
            else
            {
                Response.Redirect("/administrator/login/", true);
            }
        }
    }
}
