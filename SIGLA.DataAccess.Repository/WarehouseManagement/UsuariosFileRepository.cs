using SIGLA.Entity.DataBase.Producto;
using SIGLA.Entity.DataBase.UsuariosFile;
using SIGLA.Interface.Repository.IWarehouseManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.DataAccess.Repository.WarehouseManagement
{
        public class UsuariosFileRepository : GenericRepository<UsuariosFile>, IUsuariosFileRepository

        {
            public UsuariosFileRepository(string statement)
          : base(statement)
            {
            }











        }
    }
