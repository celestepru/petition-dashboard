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
        // GET: Login
        Data d = Data.Instance;
        MembersDB db = new MembersDB();
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        //Get user data for login
        public ActionResult Fetch(Member fetchedMember)
        {
            if(fetchedMember.Username == null || fetchedMember.Password == null)
            {
                return View("Error");
            }

            Member member = (db.Members.FirstOrDefault(m => m.Username.Equals(fetchedMember.Username)));
            if (member == null)
            {
                return View("Error");
            } else
            {
                if (member.Password == fetchedMember.Password) {

                    ViewBag.Message = "Found!";
                } else
                {
                   ViewBag.Message = "Incorrect password";
                }
            }
            return View("Index", db.Members.ToList());
        }

        public ActionResult AddMember(Member member)
        {
            //Member member = new Member { Username = "cella6", Name = "Celeste", Surname = "Prussiani", Password = "ciao", Role = "Admin" };
            if (member.Username != null && member.Name != null && member.Surname != null)
            {
                member.Role = "User";
                db.Members.Add(member);
            }

            db.SaveChanges();
            return View("Index", db.Members.ToList());
        }

        public ActionResult DB()
        {
            ViewBag.Message = db.Members.First().Name;
            return View("Index", db.Members.ToList());
        }

        [HttpGet]
        public ActionResult Edit(String id)
        {
            Member member = (db.Members.FirstOrDefault(m => m.Username.Equals(id)));
            if (member == null) return View("Error");
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Member postedMember)
        {
            Member storedMember = (db.Members.FirstOrDefault(m => m.Username.Equals(postedMember.Username)));
            storedMember.Name = postedMember.Name;
            db.SaveChanges();
            return RedirectToAction("Index", db.Members.ToList());
        }
    }
}