using DemoAppInsights.Models;
using Serilog;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DemoAppInsights.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult SlowPage()
        {
            ViewBag.Message = "This is a really slow page.";

            using (var context = new DemoAppInsightsContext())
            {
                for (var i = 0; i < 20; i++)
                {
                    var products = context.Products.ToList();
                }
                return View();
            }
        }

        public ActionResult BuggedCode(int? number)
        {
            if (!number.HasValue)
                return View();

            Log.Information("NumberTyped: {Number}", number);

            if (IsPrime(number.Value))
                throw new InvalidOperationException("This is a prime number.");

            ViewBag.Message = $"The number is {number}";
            return View();
        }

        public ActionResult Products()
        {
            using (var context = new DemoAppInsightsContext())
            {
                var products = context.Products.ToList();
                return View(products);
            }
        }

        private static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            if (number % 2 == 0) return false;

            for (var i = 3; i < number; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
