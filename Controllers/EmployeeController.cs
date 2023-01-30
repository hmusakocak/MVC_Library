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

        EmployeeManager em = new EmployeeManager(new EFEmployeeDal());
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Employees = em.TGetAll();
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
            em.TDelete(id);
            return RedirectToAction("Index");
        }

        public ActionResult GetEmployee(int id)
        {
            var emp = em.TGetByID(id);
            return View(emp);
        }

        public ActionResult UpdateEmployee(EMPLOYEE e)
        {
            em.TUpdate(e);
            return RedirectToAction("Index");
        }

    }
}