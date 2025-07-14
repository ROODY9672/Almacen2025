using SIGLA.Entity.DataBase.Compras;
using SIGLA.Entity.DataBase.ProductoFile;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Object;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class ProductoFileRepository : GenericRepository<ProductoFile>, IProductoFileRepository

    {
        public ProductoFileRepository(string statement)
      : base(statement)
        {
        }






    }
}
