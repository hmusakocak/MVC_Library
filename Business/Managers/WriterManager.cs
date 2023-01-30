using Microsoft.Ajax.Utilities;
using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal _writerDal)
        {
            this._writerDal = _writerDal;
        }
        public void TDelete(int id)
        {
            _writerDal.DeleteT(id);
        }

        public List<WRITER> TGetAll()
        {
            return _writerDal.GetAll(); 
        }

        public WRITER TGetByID(int id)
        {
            return _writerDal.GetbyID(id);
        }

        public void TInsert(WRITER entity)
        {
            _writerDal.InsertT(entity);
        }

        public void TUpdate(WRITER entity)
        {
            _writerDal.UpdateT(entity);
        }
    }
}