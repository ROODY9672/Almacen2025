using SIGLA.Entity.DataBase.Ventas;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class VentasRepository : GenericRepository<Ventas>, IVentasRepository

    {
        public VentasRepository(string statement)
      : base(statement)
        {
        }











    }
}
