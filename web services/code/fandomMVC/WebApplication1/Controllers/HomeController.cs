using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proxies;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        ProductClient proxy;
        public HomeController(ProductClient proxy)
        {
            this.proxy = proxy;
        }
        public ActionResult Index()
        {
            var model = proxy.GetProducts();
            return View(model);
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

        public ActionResult taber()
        {
            return View();
        }
    }
}