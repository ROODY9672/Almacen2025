using SIGLA.Business.Dto.Comprassss;
using SIGLA.Entity.DataBase.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Comprasss
{
    public interface IComprasMapping
    {
        Compras ToEntity(ComprasCreacionDto dto);

    }
}
