using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class RoomController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/Room
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "LREF", "NAME");
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "LREF", "NAME");
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var room = service.RoomFirst(id);
            return View(room);
        }

        public ActionResult List()
        {
            ViewBag.List = service.RoomSelect();
            return View();
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.RoomDelete(id);
            return RedirectToAction("List", "Room");
        }

        [HttpPost]
        public ActionResult Edit(ROOM b)
        {
            ViewBag.Status = Model.StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.RoomUpdate(b);
                return RedirectToAction("List", "Room");
            }
            else
                return View(b);

        }

        [HttpPost]
        public ActionResult Add(ROOM r)
        {
            ViewBag.Status = Model.StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.RoomInsert(r);
                return RedirectToAction("Add", "Room");
            }
            else
                return View(r);
        }
    }
}