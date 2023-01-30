using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class ProcessController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        MovementManager mm = new MovementManager(new EFMovementDal());
        // GET: Process
        public ActionResult Index()
        {
            return View(mm.TGetStat1());
        }

        public ActionResult DoPunishment(int id)
        {
            var movement = db_entities.MOVEMENT.Find(id);
            movement.isPenaltyApplied= true;
            db_entities.PENALTY.Add(new PENALTY
            {
                MEMBER = movement.MEMBER,
                MOVEMENT = id,
                START = movement.GET_TIME,
                FINISH = movement.MEMBER_GIVETIME,
                MONEY = (decimal)(Convert.ToInt32(movement.MEMBER_GIVETIME.Value.Subtract(movement.GET_TIME.Value).Days) * 6.27)
            }
            );
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveToServerIMG(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0) 
            {
                var filepath = Path.Combine(Server.MapPath("~/Content/Gallery"),Path.GetFileName(file.FileName));
                file.SaveAs(filepath);
            }
            return RedirectToAction("Gallery");
        }

        [HttpGet]
        public ActionResult PenaltyList()
        {
            var list = db_entities.PENALTY.ToList();
            return View(list);
        }
    }
}