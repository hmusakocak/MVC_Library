using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.DataLayer.Repository;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Library.DataLayer.EntityFramework
{
    public class EFBookDal : GenericRepository<BOOK>, IBookDal
    {
        public List<SelectListItem> GetWriterList()
        {
            DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
            List<SelectListItem> writerlist = new List<SelectListItem>();
            foreach (var item in db_entities.WRITER)
            {
                var a = new SelectListItem
                {
                    Text = item.NAME + " " + item.SURNAME,
                    Value = item.ID.ToString()
                };
                writerlist.Add(a);
            }
            return writerlist;
        }

        public List<SelectListItem> GetCategoryList() 
        {
            DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
            List<SelectListItem> catlist = new List<SelectListItem>();

            foreach (var item in db_entities.CATEGORY)
            {
                var a = new SelectListItem
                {
                    Text = item.NAME,
                    Value = item.ID.ToString()
                };
                catlist.Add(a);
            }
            return catlist;
        }


        


           

}
}