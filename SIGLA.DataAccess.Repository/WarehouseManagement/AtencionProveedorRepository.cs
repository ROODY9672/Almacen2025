using SIGLA.Entity.DataBase.AtencionProveedor;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
    public class AtencionProveedorRepository : GenericRepository<AtencionProveedor>, IAtencionProveedorRepository

    {
        public AtencionProveedorRepository(string statement)
      : base(statement)
        {
        }


    }
}
