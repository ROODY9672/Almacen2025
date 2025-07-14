using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Sucursalesss
{
    public interface ISucursalesMapping
    {

        Sucursales ToEntity(SucursalesCreacionDto dto);

        IEnumerable<SucursalesColeccionDto> ToEnumerable(IEnumerable<Sucursales> entidad);
        SucursalesObjetoDto toDto(Sucursales dto);
        Sucursales ToEntityUpdate(SucursalesObjetoDto dto);

    }
}
