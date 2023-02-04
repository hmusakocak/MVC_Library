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
            var username = (string)Session["username"];

            var listofsent = (from x in db_entities.MESSAGE select x).Where(x => x.sender_username == username).ToList();
            var listofreceived = (from x in db_entities.MESSAGE select x).Where(x => x.receiver_username == username).ToList();

            Dictionary<string, string> memberlist = new Dictionary<string, string>();


            foreach (var item in db_entities.MEMBER)
            {
                memberlist.Add(item.USERNAME, item.NAME + " " + item.SURNAME);
            }

            ViewBag.memberlist = memberlist;
            ViewBag.listofsent = listofsent;
            ViewBag.listofreceived = listofreceived;
            ViewBag.sentnumber = listofsent.Count;
            ViewBag.receivednumber = listofreceived.Count;
            if (TempData["success"] != null)
                ViewBag.success = TempData["success"];
            return View();
        }

        public ActionResult Announcement() 
        {
            return View(db_entities.ANNOUNCEMENT.ToList());
        }

        public ActionResult SendMessage(MESSAGE m)
        {
            var parameter = (string)Session["username"];
            var sendername = db_entities.MEMBER.FirstOrDefault(x => x.USERNAME == parameter);
            string SN = sendername.NAME + " " + sendername.SURNAME;
            var receivername = db_entities.MEMBER.FirstOrDefault(x => x.USERNAME == m.receiver_username);
            string RN = receivername.NAME + " " + receivername.SURNAME;

            MESSAGE msg = new MESSAGE
            {
                sender_username = parameter,
                receiver_username = m.receiver_username,
                sender_fullname = SN,
                receiver_fullname = RN,
                message1 = m.message1,
            };
            db_entities.MESSAGE.Add(msg);
            db_entities.SaveChanges();
            TempData["success"] = "<div class=\"alert alert-success alert-dismissible\"><a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">x</a><strong>Mesaj başarıyla gönderildi!</strong></div>";
            return RedirectToAction("Message");
        }

        public ActionResult Exit()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}