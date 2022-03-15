using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cw1.Models;

namespace cw1.Controllers
{
    public class HomeController : Controller
    {
        Data d = Data.Instance;
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Petitions()
        {
            return View("Petitions", d.Petitions);
        }
    }

}
