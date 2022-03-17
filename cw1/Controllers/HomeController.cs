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
        MembersDB db = new MembersDB();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Petitions()
        {
            return View("Petitions", d.Petitions);
        }

        public ActionResult AddPetition(Petition petition)
        {
            if (petition.Title != null && petition.Description != null)
            {
                d.Petitions.Add(petition);
            }
            return View("Petitions", d.Petitions);
        }
        public ActionResult AddMember(int petitionId, string username)
        {
            Member toAdd = (db.Members.FirstOrDefault(m => m.Username.Equals(username)));
            Petition toChange = d.Petitions.FirstOrDefault(p => p.Id == petitionId);
            toChange.Members.Add(toAdd);
            return View("Petitions", d.Petitions);
        }
    }

    

}
