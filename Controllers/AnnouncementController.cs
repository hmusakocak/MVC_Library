using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Library.Controllers
{
    [Authorize(Roles ="admin")]
    public class AnnouncementController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        // GET: Announcement
        public ActionResult Index()
        {
            var list = db_entities.ANNOUNCEMENT.ToList();
            ViewBag.list = list;
            return View();
        }

        [HttpPost]
        public ActionResult AddAnnouncement(ANNOUNCEMENT a)
        {
            db_entities.ANNOUNCEMENT.Add(a);
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAnnouncement(int id)
        {
            var deleted = db_entities.ANNOUNCEMENT.Find(id);
            db_entities.ANNOUNCEMENT.Remove(deleted);
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}