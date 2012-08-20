using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProjectsSemIII.Controllers
{
    public class AuthenticationController : Controller
    {
        public void Authentication()
        {
            if (Session["user-loged"] != null)
            {

            }
            else
            {
                Response.Redirect("~/member");
            }
        }

    }
}
