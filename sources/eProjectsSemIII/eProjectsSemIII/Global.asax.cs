using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using eProjectsSemIII.Models;
using eProjectsSemIII.Libs;

namespace eProjectsSemIII
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}/{param}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional, param = UrlParameter.Optional } // Parameter defaults
            ); 
            
            routes.MapRoute(
                 "HomeOnly", // Route name
                 "{controller}/{action}/{id}", // URL with parameters
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
             );

        }

        protected void Application_Start()
        {
            Database.SetInitializer<FineArtContext>(new FinelArtInitializer());
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception ex = HttpContext.Current.Server.GetLastError();
        //    if (ex is HttpException)
        //    {

        //    }
        //    else
        //    {
        //        string path = Server.MapPath("~/");
        //        Log logLib = new Log(path, "");
        //        logLib.WriteLog(ex.ToString());
        //    }

        //    Response.Redirect("~/error/");
        //}
    }
}