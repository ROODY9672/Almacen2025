using SIGLA.Entity.DataBase.Almacenes;
using SIGLA.Entity.DataBase.MarcaSucursal;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
    
        public class MarcaSucursalRepository : GenericRepository<MarcaSucursal>, IMarcaSucursalRepository

        {
            public MarcaSucursalRepository(string statement)
          : base(statement)
            {
            }





        }
}
