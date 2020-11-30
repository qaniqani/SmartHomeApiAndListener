using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class DeviceController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/Device
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = StaticValues.Status();
            ViewBag.DeviceType = StaticValues.DeviceStatus();
            ViewBag.IsDetector = StaticValues.IsDetectorStatus();
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Status = StaticValues.Status();
            ViewBag.DeviceType = StaticValues.DeviceStatus();
            ViewBag.IsDetector = StaticValues.IsDetectorStatus();
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var device = service.DeviceFirst(id);
            return View(device);
        }

        public ActionResult List()
        {
            ViewBag.List = service.DeviceSelect();
            return View();
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.DeviceDelete(id);
            return RedirectToAction("List", "Device");
        }

        [HttpPost]
        public ActionResult Edit(HOMEDEVICETYPE d)
        {
            service.DeviceUpdate(d);
            return RedirectToAction("List", "Device");
        }

        [HttpPost]
        public ActionResult Add(HOMEDEVICETYPE d)
        {
            service.DeviceInsert(d);
            return RedirectToAction("Add", "Device");
        }
    }
}