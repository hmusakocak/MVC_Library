using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {

        // GET: Panel
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();

        [HttpGet]
        public ActionResult Index()
        {
            var username = (string)Session["username"];
            var loggeduser = db_entities.MEMBER.FirstOrDefault(x => x.USERNAME == username);
            return View(loggeduser);
        }
        [HttpPost]
        public ActionResult UpdatePassword(MEMBER m)
        {
            var username = (string)Session["username"];
            var updateduser = db_entities.MEMBER.FirstOrDefault(x => x.USERNAME == username);
            updateduser.PASSWORD = m.PASSWORD;
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Message()
        {
            return View();
        }
        [Authorize]
        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}