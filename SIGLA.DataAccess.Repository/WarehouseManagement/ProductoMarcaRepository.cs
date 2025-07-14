using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.ProductoMarca;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
    
        public class ProductoMarcaRepository : GenericRepository<ProductoMarca>, IProductoMarcaRepository

        {
            public ProductoMarcaRepository(string statement)
          : base(statement)
            {
            }

        }
}
