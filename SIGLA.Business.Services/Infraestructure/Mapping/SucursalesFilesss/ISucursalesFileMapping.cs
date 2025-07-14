using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.SucursalesFile;
using SIGLA.Entity.DataBase.UsuariosFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.SucursalesFilesss
{
    public interface ISucursalesFileMapping
    {
        SucursalesFile ToEntity(SucursalesFileCreacionDto dto);
        IEnumerable<SucursalesFileColeccionDto> ToEnumerable(IEnumerable<SucursalesFile> entidad);

    }
}
