using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.ProductoUnidadMedida;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
  
        public class ProductoUnidadMedidaRepository : GenericRepository<ProductoUnidadMedida>, IProductoUnidadMedidaRepository

        {
            public ProductoUnidadMedidaRepository(string statement)
          : base(statement)
            {
            }


        }
}
