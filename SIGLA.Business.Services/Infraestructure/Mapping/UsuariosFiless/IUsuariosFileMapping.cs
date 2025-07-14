using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.UsuariosFile;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.UsuariosFiless
{
    public interface   IUsuariosFileMapping
    {
        UsuariosFile ToEntity(UsuariosFileCreacionDto dto);
        
        IEnumerable<UsuariosFileColeccionDto> ToEnumerable(IEnumerable<UsuariosFile> entidad);
        UsuariosFileColeccionDto ToDto(UsuariosFile dto);

    }
}
