using System.Web.Mvc;

namespace Smart.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}"
                //new { action = "Index" }
            );

            context.MapRoute(
                name: "Admin_Page",
                url: "Admin/{controller}/{action}",
                namespaces: new[] { "Smart.Areas.Admin.Controllers" }
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}