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

        MembersDB db = new MembersDB();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Petitions()
        {
            return View("Petitions", db.Petitions.ToList());
        }

        public ActionResult AddPetition(Petition petition)
        {
            if (petition.Title != null && petition.Description != null)
            {
                db.Petitions.Add(petition);
            }
            db.SaveChanges();
            return View("Petitions", db.Petitions.ToList());
        }
    }

    

}
