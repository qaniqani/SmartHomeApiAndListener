using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class HouseController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());

        // GET: Admin/House
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            HOME h = new HOME();
            h.CLIENTID = Guid.NewGuid().ToString().Replace("-", "").Substring(0,23);
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.SmartHomeStatus = Model.StaticValues.SmartHomeStatus();
            ViewBag.BlokList = new SelectList(service.BlokActiveSelect(), "LREF", "NAME");

            return View(h);
        }

        public ActionResult Edit()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var home = service.HomeFirst(id);
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.SmartHomeStatus = Model.StaticValues.SmartHomeStatus();
            ViewBag.BlokList = new SelectList(service.BlokActiveSelect(), "LREF", "NAME");

            return View(home);
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.HomeDelete(id);
            return RedirectToAction("List", "House");
        }

        public ActionResult List()
        {
            ViewBag.List = service.HomeSelect();
            return View();
        }

        [HttpPost]
        public ActionResult Add(HOME h)
        {
            ViewBag.Status = Model.StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.HomeInsert(h);

                return RedirectToAction("Add", "House");
            }
            else
                return View(h);
        }

        [HttpPost]
        public ActionResult Edit(HOME h)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(RouteData.Values["id"]);
                h.LREF = id;
                service.HomeUpdate(h);
                return RedirectToAction("List", "House");
            }
            return View();
        }
    }
}