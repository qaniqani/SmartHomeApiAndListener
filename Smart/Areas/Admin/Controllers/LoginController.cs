using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/Logi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var admin = service.AdminLogin(username, password);
                if (admin != null)
                {
                    Session["admin"] = admin;
                    service.SetAdminSession(admin);

                    return RedirectToAction("Index", "Home");
                }

                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            Session["admin"] = null;
            Session.Remove("admin");
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}