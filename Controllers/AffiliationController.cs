using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class AffiliationController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        MemberManager mm = new MemberManager(new EFMemberDal());
        // GET: Affiliation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(MEMBER m)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Register(MEMBER m) 
        {
            var list = db_entities.MEMBER.ToList();
            foreach (var item in list)
            {
                if (m.USERNAME == item.USERNAME)
                {
                    TempData["error"] = "Bu kullanıcı adı kullanılmaktadır!";
                }
            }
            if (TempData["error"] != null)
            {
                ViewBag.error = TempData["error"];               
            }
            else
            {
                ViewBag.error = "";
                mm.TInsert(m);
            }
            return View();
        }
    }
}