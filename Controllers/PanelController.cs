using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class PanelController : Controller
    {
        // GET: Panel
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var username = (string)Session["username"];
            var loggeduser = db_entities.MEMBER.FirstOrDefault(x=>x.USERNAME == username);
            return View(loggeduser);
        }
        
        [HttpPost]
        public ActionResult UpdatePassword(MEMBER m)
        {
            var user = (string)Session["username"];
            var updateduser = db_entities.MEMBER.FirstOrDefault(x => x.USERNAME == user);
            updateduser.PASSWORD = m.PASSWORD;
            db_entities.SaveChanges();
            return View();
        }

    }
}