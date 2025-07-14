using SIGLA.Entity.DataBase.UsuarioSucursal;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class UsuarioSucursalRepository : GenericRepository<UsuarioSucursal>, IUsuarioSucursalRepository

    {
        public UsuarioSucursalRepository(string statement)
      : base(statement)
        {
        }







    }
}
