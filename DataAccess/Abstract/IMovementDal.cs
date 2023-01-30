
using MVC_Library.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Library.DataLayer.DataAccessLayer
{
    public interface IMovementDal : IGenericDal<MOVEMENT>
    {
        List<MOVEMENT> GetStat1();
        List<MOVEMENT> GetStat0();
    }
}
