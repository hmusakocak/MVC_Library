using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class MemberManager : IMemberService
    {
        IMemberDal _memberDal;
        public MemberManager(IMemberDal _memberDal)
        {
            this._memberDal = _memberDal;
        }
        public void TDelete(int id)
        {
            _memberDal.DeleteT(id);
        }

        public List<MEMBER> TGetAll()
        {
            return _memberDal.GetAll();
        }

        public MEMBER TGetByID(int id)
        {
            return _memberDal.GetbyID(id);
        }

        public void TInsert(MEMBER entity)
        {
            _memberDal.InsertT(entity);
        }

        public void TUpdate(MEMBER entity)
        {
            _memberDal.UpdateT(entity);
        }
    }
}