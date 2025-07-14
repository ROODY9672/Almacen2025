using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.UsuariosFilessss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public  interface IUsuariosFileService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(UsuariosFileCreacionDto dto);
        Task<ResourceResponseDto<IEnumerable<UsuariosFileColeccionDto>>> ListadoFotosFiltradoTodos(int id);
        Task<ResourceResponseDto<UsuariosFileColeccionDto>> ObtenerFotoPerfilAsync(int usuarioNo);

    }
}
