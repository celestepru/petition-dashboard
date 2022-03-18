using cw1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cw1.Controllers
{
    public class LoginController : Controller
    {
        MembersDB db = new MembersDB(); //Access database (Members)

        /* Home page */
        public ActionResult Index()
        {
            ViewBag.Title = "Login";
            return View(); 
        }
        
        /* Fetch member action */
        /* Looks up member in database. Passes username of member to View so to
         add it to sessionStorage for login persistence. */
        public ActionResult Fetch(Member fetchedMember)
        {
            if(fetchedMember.Username == null || fetchedMember.Password == null)    //Check member is valid 
            {
                return View("Error");
            }

            //Find member in Database
            Member member = (db.Members.FirstOrDefault(m => m.Username.Equals(fetchedMember.Username)));

            //If member isn't in Database, show error page
            if (member == null)
            {
                return View("Error");
            } else
            {
                //If the entered password is correct, pass username to view
                if (member.Password == fetchedMember.Password) {
                    if (member.Role.Equals("Admin"))
                    {
                        ViewBag.Message = "admin:" + member.Username;   //pass special status in case admin logs in
                    } else
                    {
                        ViewBag.Message = "user:" + member.Username;
                    }
                } else
                {
                    ViewBag.Message = "Incorrect password";  //If password is incorrect, show "Incorrect" message
                }
            }
            return View("Index", db.Members.ToList());  //Return all Members
        }


        /* Add member action*/
        /* Adds a new member to the database. */
        public ActionResult AddMember(Member member)
        {
            if (member.Username != null && member.Name != null && member.Surname != null)  //check all required fields are entered
            {
                if (member.Username.Equals("admin")) //hardcode admin account in database
                {
                    member.Role = "Admin"; 
                }
                else
                {

                    member.Role = "User";   //set every other user to standard role
                }
                db.Members.Add(member); //add to Database
                //Pass member's username to view for login persistence
                ViewBag.Message = "signup:" + member.Username;
            }
            db.SaveChanges();
            return View("Index", db.Members.ToList());
        }
        
    }
}