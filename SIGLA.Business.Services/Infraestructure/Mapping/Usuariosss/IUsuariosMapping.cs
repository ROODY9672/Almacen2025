using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Entity.DataBase.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Usuariosss
{
    public interface IUsuariosMapping
    {
        Usuarios ToEntity(UsuariosCreacionDto dto);
        IEnumerable<UsuariosColeccionDto> ToEnumerable(IEnumerable<Usuarios> entidad);
        UsuarioObjetoDto toDto(Usuarios dto);
        Usuarios ToEntityUpdate(UsuarioObjetoDto dto);

    }
}
