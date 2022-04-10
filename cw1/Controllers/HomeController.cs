using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cw1.Models;

namespace cw1.Controllers
{
    //Homepage controller
    public class HomeController : Controller
    {

        Data d = Data.Instance;         //Get Data singleton instance (Petitions)
        MembersDB db = new MembersDB(); //Access Database (Members)

        /* Home page */
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }


        /* Petition page  */
        public ActionResult Petitions()
        {

            ViewBag.Title = "Petitions";
            return View("Petitions", d.Petitions);  //Return all petitions from Data instance
        }

        /* Petition page  */
        public ActionResult SinglePetition(int petitionId)
        {
            Petition single = d.Petitions.FirstOrDefault(p => p.Id == petitionId);
            return View("SinglePetition", single);  //Return all petitions from Data instance
        }

        /* Add petition action*/
        /* Creates a new petition and adds it to Data instance. (Not persistent) */
        public ActionResult AddPetition(Petition petition)
        {
            ViewBag.Title = "Petitions";
            if (petition.Title != null && petition.Description != null) //Check petition is valid
            {
                petition.Members = new List<Member>();  //Initialise List of empty members
                d.Petitions.Add(petition);
            }
            return View("Petitions", d.Petitions);  //Return all petitions from Data instance
        }


        /* Add member action*/
        /* Adds a new member to a petition's list. */
        public ActionResult AddMember(int petitionId, string username)
        {
            ViewBag.Title = "Petitions";
            Member toAdd = (db.Members.FirstOrDefault(m => m.Username.Equals(username)));   //Find member in Database
            Petition toChange = d.Petitions.FirstOrDefault(p => p.Id == petitionId);    //Find petition in Data Instance

            //If either member or petition aren't in data source, show error page
            if (toAdd == null || toChange == null)
            {
                return View("Error");
            }
            else
            {
                if(!toChange.Members.Contains(toAdd))
                {
                    toChange.Members.Add(toAdd);
                }
                    //Add member to petition's member list (sign petition)
            }
            return View("SinglePetition", toChange);  //Return all petitions from Data instance
        }

        /* Add member action*/
        /* Adds a new member to a petition's list. */
        public ActionResult DeletePetition(int petitionId)
        {
            ViewBag.Title = "Petitions";
            Petition toDelete = d.Petitions.FirstOrDefault(p => p.Id == petitionId);    //Find petition in Data Instance

            //If either member or petition aren't in data source, show error page
            if (toDelete == null)
            {
                return View("Error");
            }
            else
            {
                d.Petitions.Remove(toDelete);    //Add member to petition's member list (sign petition)
            }
            return View("Petitions", d.Petitions);  //Return all petitions from Data instance
        }
    }

    

}
