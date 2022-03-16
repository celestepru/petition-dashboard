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
            return View("Index", d.Members);
        }
    }
}