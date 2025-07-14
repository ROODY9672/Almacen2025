using SIGLA.Entity.DataBase.CompraDetalle;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
 
        public class EmpresaRepository : GenericRepository<Empresa>, IEmpresaRepository

        {
            public EmpresaRepository(string statement)
          : base(statement)
            {
            }



        }
}
