using SIGLA.Entity.DataBase.Compras;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{

    public class ComprasRepository : GenericRepository<Compras>, IComprasRepository

    {
        public ComprasRepository(string statement)
      : base(statement)
        {
        }



    }
}
