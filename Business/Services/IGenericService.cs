using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library.Services
{
    public interface IGenericService<T> where T : class
    {
         void TInsert(T entity);
         void TDelete(int id);
         void TUpdate(T entity);
         T TGetByID(int id);
         List<T> TGetAll();
    }
}
