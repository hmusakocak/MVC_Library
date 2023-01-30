using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.DataLayer.Repository;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.DataLayer.EntityFramework
{
    public class EFMovementDal : GenericRepository<MOVEMENT>, IMovementDal
    {
        public List<MOVEMENT> GetStat1()
        {
            DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();
            return db_entities.MOVEMENT.Where(k => k.STATUS == true).ToList();
        }

        public List<MOVEMENT> GetStat0()
        {
            DBKUTUPHANE_Entities db_entities = new DBKUTUPHANE_Entities();

            return db_entities.MOVEMENT.Where(k => k.STATUS == false).ToList();

        }
    }
}