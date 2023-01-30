using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library.DataLayer.DataAccessLayer
{
    public interface IGenericDal<T> where T : class
    {
        void InsertT(T entity);
        void UpdateT(T entity);
        void DeleteT(int id);       
        T GetbyID(int id);
        List<T> GetAll();
    }
}
