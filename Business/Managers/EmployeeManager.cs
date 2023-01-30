using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.Models.Entity;
using MVC_Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.Managers
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal _employeeDal)
        {
            this._employeeDal = _employeeDal;
        }
        public void TDelete(int id)
        {
            _employeeDal.DeleteT(id);
        }

        public List<EMPLOYEE> TGetAll()
        {
            return _employeeDal.GetAll();   
        }

        public EMPLOYEE TGetByID(int id)
        {
            return _employeeDal.GetbyID(id);
        }

        public void TInsert(EMPLOYEE entity)
        {
            _employeeDal.InsertT(entity);
        }

        public void TUpdate(EMPLOYEE entity)
        {
            _employeeDal.UpdateT(entity);
        }
    }
}