using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Entity.DataBase.Usuarios;
using SIGLA.Entity.DataBase.UsuarioSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.UsuarioSucursalss
{
    public interface IUsuarioSucursalMapping
    {
        UsuarioSucursal ToEntity(UsuarioSucursalCreacionDto dto);
        IEnumerable<UsuarioSucursalColeccionDto> ToEnumerable(IEnumerable<UsuarioSucursal> entidad);

    }
}
