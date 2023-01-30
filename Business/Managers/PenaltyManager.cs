using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class PenaltyManager : IPenaltyService
    {
        IPenaltyDal _penaltyDal;
        public PenaltyManager(IPenaltyDal _penaltyDal)
        {
            this._penaltyDal = _penaltyDal;
        }
        public void TDelete(int id)
        {
            _penaltyDal.DeleteT(id);
        }

        public List<PENALTY> TGetAll()
        {
           return _penaltyDal.GetAll();
        }

        public PENALTY TGetByID(int id)
        {
            return _penaltyDal.GetbyID(id);
        }

        public void TInsert(PENALTY entity)
        {
            _penaltyDal.InsertT(entity);
        }

        public void TUpdate(PENALTY entity)
        {
            _penaltyDal.UpdateT(entity);
        }
    }
}