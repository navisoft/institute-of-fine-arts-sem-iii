using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eProjectsSemIII.Models;

namespace eProjectsSemIII.Controllers
{
    public class AuthenticationController : Controller
    {
        public void Authentication()
        {
            if (Session["user-loged"] != null)
            {
                try
                {
                    string username = Session["user-loged"].ToString();
                    new FineArtContext().Members.Where(m => m.Username == username).First();
                }
                catch
                {
                    Response.Redirect("~/member", true);
                }
            }
            else
            {
                Response.Redirect("~/member", true);
            }
        }
    }
}
   
