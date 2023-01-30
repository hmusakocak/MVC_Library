using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Library.Managers
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal _bookDal)
        {
            this._bookDal = _bookDal;
        }
        public void TDelete(int id)
        {
            _bookDal.DeleteT(id);
        }

        public List<BOOK> TGetAll()
        {
            return _bookDal.GetAll();
        }

        public BOOK TGetByID(int id)
        {
            return _bookDal.GetbyID(id);
        }

        public void TInsert(BOOK entity)
        {
            _bookDal.InsertT(entity);
        }

        public void TUpdate(BOOK entity)
        {
            _bookDal.UpdateT(entity);
        }

        public List<SelectListItem> GetWriterList()
        {
            return _bookDal.GetWriterList();
        }

        public List<SelectListItem> GetCategoryList()
        {
            return _bookDal.GetCategoryList();
        }
    }
}