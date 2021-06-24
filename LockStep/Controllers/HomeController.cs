using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LockStep.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.String = "its a string!";
            ViewBag.StringList = new List<string>
            {
                "string 1",
                "string 2",
                "string 3",
                "string 4",
                "string 5",
                "string 6",
            };
            var dictionary = new Dictionary<string, string>
            {
                { "key1", "string 1" },
                { "key2", "string 2" },
                { "key3", "string 3" },
                { "key4", "string 4" },
                { "key5", "string 5" },
                { "key6", "string 6" },
            };
            ViewBag.StringDictionary = dictionary;

            return View(dictionary);
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