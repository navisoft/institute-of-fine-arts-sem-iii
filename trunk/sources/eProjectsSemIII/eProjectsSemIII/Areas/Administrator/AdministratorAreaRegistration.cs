using System.Web.Mvc;

namespace eProjectsSemIII.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new {controller = "Index", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
