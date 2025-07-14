using SIGLA.Business.Dto.CompraDetallesss;
using SIGLA.Entity.DataBase.CompraDetalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.CompraDetalless
{
    public interface ICompraDetalleMapping
    {
        CompraDetalle ToEntity(CompraDetalleCreacionDto dto);

    }
}
