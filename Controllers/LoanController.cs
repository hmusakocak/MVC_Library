using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class LoanController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        MovementManager mm = new MovementManager(new EFMovementDal());
        // GET: Loan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GiveBook(MOVEMENT m)
        {
            LoanValidator lv = new LoanValidator();
            var result = lv.Validate(m);

            db_entities.MOVEMENT.Add(m);
            var bookstatcontrol = db_entities.BOOK.Find(m.BOOK);
            if (result.IsValid)
            {
                if (bookstatcontrol.STATUS == false)
                {
                    ViewBag.errormsg = "Bu kitap ödünç verilemez!";
                    db_entities.MOVEMENT.Remove(m);
                    db_entities.SaveChanges();
                    return View();
                }
                else
                {
                    db_entities.SaveChanges();
                    System.Threading.Thread.Sleep(500);
                    return RedirectToAction("MovementList", "Loan");
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                if (bookstatcontrol != null && bookstatcontrol.STATUS == false)
                {
                    ViewBag.errormsg = "Bu kitap ödünç verilemez!";
                }
                return View();
            }
        }

        [HttpGet]
        public ActionResult GiveBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MovementList()
        {
            System.Threading.Thread.Sleep(500);
            return View(mm.TGetStat0());
        }

        public ActionResult Refund(int id)
        {
            var movement = db_entities.MOVEMENT.Find(id);
            return View(movement);
        }

        public ActionResult UpdateMovement(MOVEMENT m)
        {

            var x = db_entities.MOVEMENT.Find(m.ID);
            x.MEMBER_GIVETIME = m.MEMBER_GIVETIME;
            x.STATUS = m.STATUS;
            db_entities.SaveChanges();
            return RedirectToAction("MovementList", "Loan");
        }
    }
}