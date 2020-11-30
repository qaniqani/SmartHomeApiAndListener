using SmartApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using SmartApi.Domain.Services;

namespace Smart.Controllers
{
    public class HomeController : Controller
    {
        private const string conn = "SmartHome";
        SmartDbContext db = new SmartDbContext(conn);

        public HomeController()
        {
            
        }

        public ActionResult Index()
        {
            var b = new BLOK
            {
                NAME = "Test",
                STATUS = 1
            };

            db.Bloks.Add(b);
            db.SaveChanges();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}