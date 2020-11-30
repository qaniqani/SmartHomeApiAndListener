using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class RoomDeviceController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/RoomDevice
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.RoomList = new SelectList(service.RoomActiveSelect(), "LREF", "HOMENAME");
            ViewBag.DeviceList = new SelectList(service.DeviceActiveSelect(), "LREF", "NAME");
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.RoomList = new SelectList(service.RoomActiveSelect(), "LREF", "HOMENAME");
            ViewBag.DeviceList = new SelectList(service.DeviceActiveSelect(), "LREF", "NAME");

            int id = Convert.ToInt32(RouteData.Values["id"]);
            var device = service.RoomDeviceFirst(id);
            return View(device);
        }

        public ActionResult List()
        {
            ViewBag.List = service.RoomDeviceList();
            return View();
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.RoomDeviceDelete(id);
            return RedirectToAction("List", "RoomDevice");
        }

        [HttpPost]
        public ActionResult Edit(ROOMDEVICEVALUE d)
        {
            ViewBag.Status = Model.StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.RoomDeviceUpdate(d);
                return RedirectToAction("List", "RoomDevice");
            }
            else
                return View(d);

        }

        [HttpPost]
        public ActionResult Add(ROOMDEVICEVALUE d)
        {
            ViewBag.Status = Model.StaticValues.Status();
            d.UPDATETIME = DateTime.Now;
            d.USERREF = 0;
            if (ModelState.IsValid)
            {
                service.RoomDeviceInsert(d);
                return RedirectToAction("Add", "RoomDevice");
            }
            else
                return View(d);
        }
    }
}