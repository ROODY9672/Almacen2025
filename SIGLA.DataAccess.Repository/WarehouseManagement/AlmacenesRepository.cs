using SIGLA.Entity.DataBase.Almacenes;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
    public class AlmacenesRepository : GenericRepository<Almacenes>, IAlmacenesRepository

    {
        public AlmacenesRepository(string statement)
      : base(statement)
        {
        }


    }
}
