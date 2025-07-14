using SIGLA.Entity.DataBase.Clientes;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{


    public class ClientesRepository : GenericRepository<Clientes>, IClientesRepository

    {
        public ClientesRepository(string statement)
      : base(statement)
        {
        }


    }
}
