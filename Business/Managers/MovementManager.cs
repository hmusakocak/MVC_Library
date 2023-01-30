using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class MovementManager : IMovementService
    {
        IMovementDal _movementDal;
        public MovementManager(IMovementDal _movementDal)
        {
            this._movementDal = _movementDal;
        }
        public void TDelete(int id)
        {
            _movementDal.DeleteT(id);
        }

        public MOVEMENT TGetByID(int id)
        {
            return _movementDal.GetbyID(id);
        }

        public void TInsert(MOVEMENT entity)
        {
            _movementDal.InsertT(entity);
        }

        public void TUpdate(MOVEMENT entity)
        {
            _movementDal.UpdateT(entity);
        }
        public List<MOVEMENT> TGetStat1()
        {
            return _movementDal.GetStat1();
        }
        public List<MOVEMENT> TGetStat0()
        {
            return _movementDal.GetStat0();
        }

        public List<MOVEMENT> TGetAll()
        {
            return _movementDal.GetAll();
        }
    }
}