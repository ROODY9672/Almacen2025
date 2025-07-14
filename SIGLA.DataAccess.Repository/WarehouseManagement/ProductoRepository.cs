using SIGLA.Entity.DataBase.Producto;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository

    {
        public ProductoRepository(string statement)
      : base(statement)
        {
        }











    }
}
