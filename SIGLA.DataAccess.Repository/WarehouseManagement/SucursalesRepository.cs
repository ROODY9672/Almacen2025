using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class SucursalesRepository : GenericRepository<Sucursales>, ISucursalesRepository

    {
        public SucursalesRepository(string statement)
      : base(statement)
        {
        }


    }
}
