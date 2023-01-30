using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MVC_Library.Controllers
{
    public class EmployeeController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();

        EmployeeManager em = new EmployeeManager(new EFEmployeeDal());
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var list = from x in db_entities.EMPLOYEE select x;
            ViewBag.Employees = list.ToList();
            if (TempData["error"] != null)
            { ViewBag.error = TempData["error"]; }
            else
            {
                ViewBag.error = "";
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(EMPLOYEE e)
        {
            EmployeeValidator ev = new EmployeeValidator();
            var result = ev.Validate(e);

            if (result.IsValid)
            {
                em.TInsert(e);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    if (item.PropertyName == "EMPLOYEE1")
                    { TempData["error"] = item.ErrorMessage; }
                }
                return RedirectToAction("Index");
            }

        }

        public ActionResult DeleteEmployee(int id)
        {
            var rmv = db_entities.EMPLOYEE.Find(id);
            db_entities.EMPLOYEE.Remove(rmv);
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            var emp = db_entities.EMPLOYEE.Find(id);
            return View(emp);
        }

        public ActionResult UpdateEmployee(EMPLOYEE e)
        {
            var updemp = db_entities.EMPLOYEE.Find(e.ID);
            updemp.EMPLOYEE1 = e.EMPLOYEE1;
            db_entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}