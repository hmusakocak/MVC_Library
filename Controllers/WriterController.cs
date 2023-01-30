using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());
        // GET: Writer
        public ActionResult Index()
        {
            if (TempData["name_error"] != null)
            { ViewBag.nameerror = TempData["name_error"].ToString(); }
            else
            {
                ViewBag.nameerror = "";
            }

            if (TempData["surname_error"] != null)
            { ViewBag.surnameerror = TempData["surname_error"].ToString(); }
            else
            {
                ViewBag.error = "";
            }

            return View(wm.TGetAll());
        }

        public ActionResult AddWriter(WRITER w) 
        {
            WriterValidator wv = new WriterValidator();
            var result = wv.Validate(w);
            if (result.IsValid)
            {
                wm.TInsert(w);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    if (item.PropertyName == "NAME")
                    {
                        TempData["name_error"] = item.ErrorMessage;
                    }
                     if (item.PropertyName == "SURNAME")
                    {
                        TempData["surname_error"] = item.ErrorMessage;
                    }
                }
                return RedirectToAction("Index");
            }

        }

        public ActionResult DeleteWriter(int id)
        { 
            wm.TDelete(id);
            return RedirectToAction("Index");
        }

        public ActionResult GetWriter(int id)
        {
            return View(wm.TGetByID(id));
        }

        public ActionResult UpdateWriter(WRITER w)
        {
            wm.TUpdate(w);
            return RedirectToAction("Index");
        }

    }
}