using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = StaticValues.Status();
            return View();
        }

        [HttpPost]
        public ActionResult Add(ADMIN admin)
        {
            admin.DATETIME = DateTime.Now;
            if (ModelState.IsValid)
            {
                service.AdminInsert(admin);
                return RedirectToAction("Add");
            }

            ViewBag.Status = StaticValues.Status();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(ADMIN admin)
        {
            admin.DATETIME = DateTime.Now;
            if (ModelState.IsValid)
            {
                service.AdminUpdate(admin);
                return RedirectToAction("List");
            }

            ViewBag.Status = StaticValues.Status();
            return View(admin);
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.AdminDelete(id);
            return RedirectToAction("List");
        }
        public ActionResult Edit()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            ViewBag.Status = StaticValues.Status();
            var admin = service.AdminFirst(id);
            return View(admin);
        }

        public ActionResult List()
        {
            ViewBag.Status = StaticValues.Status();
            ViewBag.List = service.AdminSelect();
            return View();
        }
    }
}