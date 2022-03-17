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
            return View(d.Members);
        }

        public ActionResult AddMember(Member member)
        {
            if (member.Username != null && member.Name != null && member.Surname != null)
            {
                member.Role = "User";
                d.Members.Add(member);
            }

            d.SaveMembers();
            return View("Index", db.Members.ToList());
        }

        public ActionResult DB()
        {
            //Member member = new Member { Username = "cella6", Name = "Celeste", Surname = "Prussiani", Password = "ciao", Role = "Admin" };
            //db.Members.Add(member);
            //db.SaveChanges();
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