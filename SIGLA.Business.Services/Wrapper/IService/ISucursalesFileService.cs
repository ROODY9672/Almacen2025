using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.SucursalesFilesss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface   ISucursalesFileService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(SucursalesFileCreacionDto dto);
        Task<ResourceResponseDto<IEnumerable<SucursalesFileColeccionDto>>> ListadoFotosFiltradoTodos(int id);

    }
}
