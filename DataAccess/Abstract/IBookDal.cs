using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_Library.DataLayer.DataAccessLayer
{
    public interface IBookDal : IGenericDal<BOOK>
    {
         List<SelectListItem> GetWriterList();
         List<SelectListItem> GetCategoryList();
    }
}
