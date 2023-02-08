using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MVC_Library.Controllers
{
    [Authorize(Roles = "admin")]

    public class StatisticsController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        // GET: Statistics
        public ActionResult Index()
        {
            ViewBag.total_user = db_entities.MEMBER.Count();
            ViewBag.given_book = db_entities.BOOK.Where(k => k.STATUS == false).Count();
            var x = db_entities.PENALTY.Sum(k => k.MONEY);
            ViewBag.total_cash = x;
            ViewBag.given_movement = db_entities.MOVEMENT.Where(k=>k.STATUS == true).Count();
            return View();
                
        }
    }
}