using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MVC_Library.DataLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        
        public void DeleteT(int id)
        {
            using (DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities())
            {
                db_entities.Set<T>().Remove(db_entities.Set<T>().Find(id));
                db_entities.SaveChanges();
            }                
        }

        public List<T> GetAll()
        {
            DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
            return db_entities.Set<T>().ToList();
        }

        public T GetbyID(int id)
        {
            using (DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities())
            {
                return db_entities.Set<T>().Find(id);
            }
        }

        public void InsertT(T entity)
        {
            using (DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities())
            {
                db_entities.Set<T>().Add(entity);
                db_entities.SaveChanges();
            }
        }

        public void UpdateT(T entity)
        {
            using (DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities())
            {
                db_entities.Set<T>().AddOrUpdate(entity);
                db_entities.SaveChanges();
            }
        }
    }
}