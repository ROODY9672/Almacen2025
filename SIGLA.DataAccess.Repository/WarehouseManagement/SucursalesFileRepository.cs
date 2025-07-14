using SIGLA.Entity.DataBase.CompraDetalle;
using SIGLA.Entity.DataBase.SucursalesFile;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
 
        public class SucursalesFileRepository : GenericRepository<SucursalesFile>, ISucursalesFileRepository

        {
            public SucursalesFileRepository(string statement)
          : base(statement)
            {
            }








        }
}
