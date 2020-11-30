using System.Web.Mvc;

namespace Smart.Areas.WebUser
{
    public class WebUserAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "WebUser";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "WebUser_default",
                "WebUser/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, clientId = UrlParameter.Optional }
            );
            context.MapRoute(
                "WebUser_default1",
                "WebUser/{controller}/{action}/{id}/{clientId}",
                new { action = "Index", id = UrlParameter.Optional, clientId = UrlParameter.Optional }
            );
        }
    }
}