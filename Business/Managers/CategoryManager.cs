using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal _categoryDal)
        {
            this._categoryDal = _categoryDal;
        }
        public void TDelete(int id)
        {
            _categoryDal.DeleteT(id);
        }

        public List<CATEGORY> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public CATEGORY TGetByID(int id)
        {
            return _categoryDal.GetbyID(id);
        }

        public void TInsert(CATEGORY entity)
        {
            _categoryDal.InsertT(entity);
        }

        public void TUpdate(CATEGORY entity)
        {
            _categoryDal.UpdateT(entity);
        }
    }
}