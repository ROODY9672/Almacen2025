using SIGLA.Entity.DataBase.Proveedores;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
    

        public class ProveedoresRepository : GenericRepository<Proveedores>, IProveedoresRepository

    {
            public ProveedoresRepository(string statement)
          : base(statement)
            {
            }








        }
}
