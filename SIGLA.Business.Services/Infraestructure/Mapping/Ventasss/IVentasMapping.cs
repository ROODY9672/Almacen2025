using SIGLA.Business.Dto.Ventassss;
using SIGLA.Entity.DataBase.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Ventasss
{
    public interface IVentasMapping
    {
        Ventas ToEntity(VentasCreacionDto dto);

    }
}
