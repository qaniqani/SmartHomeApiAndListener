using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.WebUser.Controllers
{
    public class DashboardController : Base
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());

        // GET: WebUser/Dashboard
        public ActionResult LeftMenu()
        {
            var user = service.GetUser();
            if (user != null)
            {
                var rooms = service.RoomList(user.HomeClientId).Rooms;
                //ViewData.Model = rooms;
                return PartialView("LeftMenu", rooms);
            }
            return PartialView("LeftMenu");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "cihazlar & durumları";
            TempData["Master.Title"] = "Genel Durum";
            TempData["Master.SubTitle"] = "cihazlar & durumları";

            var user = service.GetUser();
            ViewBag.User = user;
            var device = service.GetIsDetectorDevice(user.HomeClientId, (int)StaticValues.IsDetector.Yes);
            return View(device);
        }
    }
}