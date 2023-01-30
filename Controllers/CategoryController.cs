using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class CategoryController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        // GET: Category
        public ActionResult Index()
        {
            if (TempData["message"] != null)
            { ViewBag.error = TempData["message"].ToString(); }
            else
            {
                ViewBag.error = "";
            }
            return View(cm.TGetAll());
        }

        public ActionResult AddCategory(CATEGORY category)
        {
            CategoryValidator cv = new CategoryValidator();
            var result = cv.Validate(category);
            if (result.IsValid)
            {
                cm.TInsert(category);
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Bu alan boş bırakılamaz!";
                return RedirectToAction("Index");
            }

        }

        public ActionResult DeleteCategory(int id)
        {
            cm.TDelete(id);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int id)
        {
            var catID = db_entities.CATEGORY.Find(id);
            return View(catID);
        }

        public ActionResult EditCategory(CATEGORY ctg)
        {
            cm.TUpdate(ctg);
            return RedirectToAction("Index");

        }
    }
}