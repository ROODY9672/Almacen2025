using SIGLA.Business.Dto.Comprassss;
using SIGLA.Business.Dto.MarcaSucursalsss;
using SIGLA.Entity.DataBase.Compras;
using SIGLA.Entity.DataBase.MarcaSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.MarcaSucursalss
{
     public interface IMarcaSucursalMapping
    {
        MarcaSucursal ToEntity(MarcaSucursalCreacionDto dto);

    }
}
