using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SmartApi.Providers;

namespace Smart.Areas.WebUser.Controllers
{
    public class RoomController : Base
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());

        // GET: WebUser/Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Device(int id)
        {
            if (service.GetUser() != null)
            {
                string clientId = service.GetUser().HomeClientId;
                var roomDevice = service.GetRoomDeviceStatus(clientId, id);

                ViewBag.Title = roomDevice.Room.Name + "cihazlar & durumları";
                TempData["Master.Title"] = roomDevice.Room.Name;
                TempData["Master.SubTitle"] = "cihazlar & durumları";

                ViewBag.room = roomDevice.Room;
                ViewBag.device = roomDevice.DeviceValue;

                var user = service.GetUser();

                return View(user);
            }

            return null;
        }
    }
}