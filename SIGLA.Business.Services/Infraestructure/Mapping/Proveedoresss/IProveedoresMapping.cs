using SIGLA.Business.Dto.Proveedoressss;
using SIGLA.Entity.DataBase.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Proveedoresss
{
   public  interface IProveedoresMapping
    {
        Proveedores ToEntity(ProveedoresCreacionDto dto);

    }
}
