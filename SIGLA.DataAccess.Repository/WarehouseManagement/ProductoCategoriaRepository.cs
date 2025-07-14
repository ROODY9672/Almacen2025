using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.ProductoCategoria;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{


    public class ProductoCategoriaRepository : GenericRepository<ProductoCategoria>, IProductoCategoriaRepository

    {
        public ProductoCategoriaRepository(string statement)
      : base(statement)
        {
        }



    }
}
