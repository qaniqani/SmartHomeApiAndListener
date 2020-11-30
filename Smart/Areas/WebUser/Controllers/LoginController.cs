using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Smart.Services;
using SmartApi.Providers;

namespace Smart.Areas.WebUser.Controllers
{
    public class LoginController : Controller
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        private SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        private MQTTService mqtt = new MQTTService();

        // GET: WebUser/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = service.UserLogin(username, password);
                if (user != null)
                {
                    mqtt.Subscribe(user.Topic);
                    Session["user"] = user;
                    service.SetSession(user);

                    return RedirectToAction("Index", "Dashboard");
                }

                return View();
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult LogOut()
        {
            Session["user"] = null;
            Session.Remove("user");
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}