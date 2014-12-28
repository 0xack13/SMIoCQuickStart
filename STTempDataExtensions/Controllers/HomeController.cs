using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using STTempDataExtensions.Infrastructure;

namespace STTempDataExtensions.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customer = new Customer();

            TempData.Put(customer); // Strongly typed without key

            TempData.Put("key1", customer); // Strongly typed with extra key

            var tempDataCustomer = TempData.Get<Customer>(); // Get customer without key

            var tempDataCustomerWithKey = TempData.Get<Customer>("key1"); // Get customer with key


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