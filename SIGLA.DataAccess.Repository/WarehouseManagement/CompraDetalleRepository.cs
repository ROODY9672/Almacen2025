using SIGLA.Entity.DataBase.CompraDetalle;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{


    public class CompraDetalleRepository : GenericRepository<CompraDetalle>, ICompraDetalleRepository

    {
        public CompraDetalleRepository(string statement)
      : base(statement)
        {
        }



    }
}
