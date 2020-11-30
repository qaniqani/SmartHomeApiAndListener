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
    public class UserController : Base
    {
        private static string _localUserName = WebConfigurationManager.AppSettings["local.User"];
        private static string _localPassword = WebConfigurationManager.AppSettings["local.Password"];

        SmartService service = new SmartService(_localUserName, _localPassword, Tool.GetConnectionString());
        // GET: WebUser/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            TempData["Master.Title"] = "Kullanıcı Ekle";
            TempData["Master.SubTitle"] = "Eve yeni kullanıcı tanımla";
            var currentUser = service.GetUser();
            if (currentUser.UserType != (int)StaticValues.UserType.ParentUser)
            {
                ViewBag.Status = StaticValues.Status();
                ViewBag.UserType = StaticValues.ParentUserStatus();
                ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                USER user = new USER
                {
                    HOMECLIENTID = currentUser.HomeClientId,
                    SMARTHOMESTATUS = currentUser.SmartHomeStatus
                };
                return View(user);
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult Edit(string clientId, int id)
        {
            TempData["Master.Title"] = "Kullanıcı Düzenle";
            TempData["Master.SubTitle"] = "Kullanıcının bilgilerini düzenle";
            var currentUser = service.GetUser();
            if (currentUser.UserType != (int)StaticValues.UserType.ParentUser)
            {
                if (clientId == currentUser.HomeClientId)
                {
                    ViewBag.Status = StaticValues.Status();
                    ViewBag.UserType = StaticValues.ParentUserStatus();
                    ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                    var user = service.UserPageFirst(currentUser.HomeClientId, id);
                    return View(user);
                }
                return RedirectToAction("List");
            }

            return RedirectToAction("Index", "Dashboard");
        }

        public ActionResult List()
        {
            TempData["Master.Title"] = "Evin Kullanıcıları";
            TempData["Master.SubTitle"] = "Evin tüm kullanıcıları";
            var currentUser = service.GetUser();
            if (currentUser.UserType != (int) StaticValues.UserType.ParentUser)
            {
                ViewBag.List = service.UserPageSelect(currentUser.HomeClientId);
                return View();
            }
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpPost]
        public ActionResult Add(USER u)
        {
            var currentUser = service.GetUser();
            u.HOMECLIENTID = currentUser.HomeClientId;
            if (ModelState.IsValid)
            {
                service.UserInsert(u);
                return RedirectToAction("Add");
            }
            else
            {
                ViewBag.Status = StaticValues.Status();
                ViewBag.UserType = StaticValues.ParentUserStatus();
                ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                return View(u);
            }
        }

        [HttpPost]
        public ActionResult Edit(USER u)
        {
            if (ModelState.IsValid)
            {
                service.UserUpdate(u);
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Status = StaticValues.Status();
                ViewBag.UserType = StaticValues.ParentUserStatus();
                ViewBag.SmartHomeStatus = StaticValues.SmartHomeStatus();
                return View(u);
            }
        }
    }
}