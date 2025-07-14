using SIGLA.Entity.DataBase.AlmacenesFile;
using SIGLA.Entity.DataBase.CompraDetalle;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{


    public class AlmacenesFileRepository : GenericRepository<AlmacenesFile>, IAlmacenesFileRepository

    {
        public AlmacenesFileRepository(string statement)
      : base(statement)
        {
        }

    }
}
