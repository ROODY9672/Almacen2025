using SIGLA.Entity.DataBase.VentasDetalle;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class VentasDetalleRepository : GenericRepository<VentasDetalle>, IVentasDetalleRepository

    {
        public VentasDetalleRepository(string statement)
      : base(statement)
        {
        }





    }
}
