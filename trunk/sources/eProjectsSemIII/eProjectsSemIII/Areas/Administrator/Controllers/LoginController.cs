using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Libs;

namespace eProjectsSemIII.Areas.Administrator.Controllers
{
    /**
     * @class: LoginController
     * @Any user who wants to go to administrator page must login
     * @author: Le Dang Son
     * @date: 06/08/2012
     */
    public class LoginController : Controller
    {
        /**
         * @function: Index
         * @Show login form and check admin
         * @param name="form":data for login
         * @returns:if is admin:redirect to admin index page else show login form
         * @author: Le Dang Son
         * @date: 06/08/2012
         */
        public ActionResult Index(FormCollection form)
        {
            if (Session["total_login"] != null && 4 - (int)Session["total_login"] <= 0)
            {
                return Redirect("/");
            }
            else
            {
                if (form["submit_admin_login"] != null && form["submit_admin_login"] == "Login Admin")
                {
                    if (form["username"] == "tinhphong" && form["password"] == "123456")
                    {
                        Session["admin"] = form["username"];
                        return Redirect("/administrator/");
                    }
                    else
                    {
                        if (Session["total_login"] == null)
                        {
                            Session["total_login"] = 1;
                        }
                        else
                        {
                            string path = Server.MapPath("~/");
                            Log log = new Log(path,"LoginController.Index");
                            log.WriteLog("Username: " + form["username"] + " Password: " + form["password"]);
                            Session["total_login"] = (int)Session["total_login"] + 1;
                        }
                        ViewBag.form_error = "Username or password wrong. Try again! You have to login " +
                                (5 - (int)Session["total_login"]) + " time!";
                    }
                }
            }
            return View();
        }

    }
}
