using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            List<SelectListItem> memberlist = (from mm in db_entities.MEMBER.ToList() select new SelectListItem { Text = mm.NAME, Value = mm.ID.ToString() }).ToList();
            List<SelectListItem> booklist = (from b in db_entities.BOOK.Where(x => x.STATUS == true).ToList() select new SelectListItem { Text = b.NAME, Value = b.ID.ToString() }).ToList();
            List<SelectListItem> employeelist = (from e in db_entities.EMPLOYEE.ToList() select new SelectListItem { Text = e.EMPLOYEE1, Value = e.ID.ToString() }).ToList();

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
                    ViewBag.memberlist = memberlist;
                    ViewBag.booklist = booklist;
                    ViewBag.employeelist = employeelist;
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
                ViewBag.memberlist = memberlist;
                ViewBag.booklist = booklist;
                ViewBag.employeelist = employeelist;
                return View();
            }
        }

        [HttpGet]
        public ActionResult GiveBook()
        {
            List<SelectListItem> memberlist = (from m in db_entities.MEMBER.ToList() select new SelectListItem { Text = m.NAME, Value= m.ID.ToString() }).ToList();
            List<SelectListItem> booklist = (from b in db_entities.BOOK.Where(x=>x.STATUS == true).ToList() select new SelectListItem { Text = b.NAME, Value= b.ID.ToString() }).ToList();
            List<SelectListItem> employeelist = (from e in db_entities.EMPLOYEE.ToList() select new SelectListItem { Text = e.EMPLOYEE1 , Value= e.ID.ToString() }).ToList();

            
            ViewBag.memberlist = memberlist; 
            ViewBag.booklist = booklist; 
            ViewBag.employeelist = employeelist; 
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