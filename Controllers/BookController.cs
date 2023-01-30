using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.DataLayer.EntityFramework;
using MVC_Library.FluentValidation;
using MVC_Library.Managers;
using MVC_Library.Models.Entity;

namespace MVC_Library.Controllers
{
    public class BookController : Controller
    {
        DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
        BookManager bm = new BookManager(new EFBookDal());
        // GET: Book
        public ActionResult Index(string search)
        {
            var booklist = from x in db_entities.BOOK select x;

            if (!string.IsNullOrEmpty(search))
            {
                booklist = booklist.Where(x => x.NAME.Contains(search));
            }
            return View(booklist.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            ViewBag.catlist = bm.GetCategoryList();
            ViewBag.writerlist = bm.GetWriterList();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(BOOK b)
        {
            BookValidator bv = new BookValidator();
            var result = bv.Validate(b);
            ViewBag.catlist = bm.GetCategoryList();
            ViewBag.writerlist = bm.GetWriterList();

            if (result.IsValid)
            {
                bm.TInsert(b);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View("AddBook");
            }
        }

        public ActionResult DeleteBook(int id)
        {
            bm.TDelete(id);
            return RedirectToAction("Index");
        }

        public ActionResult GetBook(int id)
        {
            var get = bm.TGetByID(id);
            ViewBag.catlist = bm.GetCategoryList();
            ViewBag.writerlist = bm.GetWriterList();
            return View("GetBook", get);
        }

        public ActionResult UpdateBook(BOOK b)
        {
            bm.TUpdate(b);
            return RedirectToAction("Index");
        }
    }
}