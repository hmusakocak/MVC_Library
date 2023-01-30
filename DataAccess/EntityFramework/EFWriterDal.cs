using MVC_Library.DataLayer.DataAccessLayer;
using MVC_Library.DataLayer.Repository;
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Library.DataLayer.EntityFramework
{
    public class EFWriterDal : GenericRepository<WRITER> , IWriterDal
    {
    }
}