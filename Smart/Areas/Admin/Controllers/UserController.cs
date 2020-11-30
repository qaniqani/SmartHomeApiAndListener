using System;
using System.Web.Configuration;
using System.Web.Mvc;
using Model;
using SmartApi.Providers;

namespace Smart.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Status = StaticValues.Status();
            ViewBag.UserType = StaticValues.UserStatus();
            ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
            ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "CLIENTID", "NAME");
            return View();
        }

        public ActionResult Edit()
        {
            ViewBag.Status = Model.StaticValues.Status();
            ViewBag.UserType = Model.StaticValues.UserStatus();
            ViewBag.SmartHomeStatus = Model.StaticValues.SmartHomeStatus();
            ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "CLIENTID", "NAME");

            int id = Convert.ToInt32(RouteData.Values["id"]);
            var user = service.UserFirst(id);
            return View(user);
        }

        public ActionResult List()
        {
            ViewBag.List = service.UserSelect();
            return View();
        }

        public ActionResult Delete()
        {
            int id = Convert.ToInt32(RouteData.Values["id"]);
            service.UserDelete(id);
            return RedirectToAction("List", "User");
        }

        [HttpPost]
        public ActionResult Edit(USER u)
        {
            if (ModelState.IsValid)
            {
                service.UserUpdate(u);
                return RedirectToAction("List", "User");
            }
            else
            {
                ViewBag.Status = StaticValues.Status();
                ViewBag.UserType = StaticValues.UserStatus();
                ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "CLIENTID", "NAME");

                return View(u);
            }
        }

        [HttpPost]
        public ActionResult Add(USER u)
        {
            if (ModelState.IsValid)
            {
                service.UserInsert(u);
                return RedirectToAction("Add", "User");
            }
            else
            {
                ViewBag.Status = StaticValues.Status();
                ViewBag.UserType = StaticValues.UserStatus();
                ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                ViewBag.HomeList = new SelectList(service.HomeActiveSelect(), "CLIENTID", "NAME");

                return View(u);
            }
        }
    }
}