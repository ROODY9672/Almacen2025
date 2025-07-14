using SIGLA.Business.Dto.VentasDetallesss;
using SIGLA.Entity.DataBase.VentasDetalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.VentasDetalless
{
    public interface IVentasDetalleMapping
    {
        VentasDetalle ToEntity(VentasDetalleCreacionDto dto);

    }
}
