using System.Web.Configuration;
using System.Web.Mvc;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (requestContext.HttpContext.Session["admin"] != null)
            {
                ViewBag.user = service.GetUser();
                return;
            }

            requestContext.HttpContext.Response.Clear();
            requestContext.HttpContext.Response.Redirect(Url.Action("Index", "Login"));
            requestContext.HttpContext.Response.End();
        }
    }
}