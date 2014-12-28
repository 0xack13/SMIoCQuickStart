using mongodbProvider.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mongodbProvider.Controllers
{
    public class HomeController : MongoControllerBase
    {
        public ActionResult Index()
        {
            //return View();
            TempData["CurrentDateTime"] = DateTime.Now;
            TempData["MeaningOfLife"] = 42;

            return Content("TempData Updated");
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

        public ActionResult ReadTempData()
        {
            return View();
        }
    }
}