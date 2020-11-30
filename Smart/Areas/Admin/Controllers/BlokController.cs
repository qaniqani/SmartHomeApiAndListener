using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class BlokController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/Blok
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = StaticValues.Status();
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Status = StaticValues.Status();
            int id = Convert.ToInt32(RouteData.Values["id"]);
            var blok = service.BlokFirst(id);
            return View(blok);
        }

        public ActionResult List()
        {
            ViewBag.List = service.BlokSelect();
            return View();
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.BlokDelete(id);
            return RedirectToAction("List", "Blok");
        }

        [HttpPost]
        public ActionResult Edit(BLOK b)
        {
            ViewBag.Status = StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.BlokUpdate(b);
                return RedirectToAction("List", "Blok");
            }
            else
                return View(b);

        }

        [HttpPost]
        public ActionResult Add(BLOK b)
        {
            ViewBag.Status = StaticValues.Status();
            if (ModelState.IsValid)
            {
                service.BlokInsert(b);
                return View();
            }
            else
                return View(b);
        }
    }
}