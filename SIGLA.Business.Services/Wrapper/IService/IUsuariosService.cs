using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IUsuariosService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(UsuariosCreacionDto dto);

        Task<ResourceResponseDto<UsuarioDto>> ValidarLoginAsync(UsuarioLoginDto dto);
        Task<UsuarioDto> ValidarLogin(UsuarioLoginDto dto);
        Task<ResourceResponseDto<int>> RegisterUsuarioCompletoAsync(UsuariosCreacionDto parameter);
        Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ListadoUsuariosConSucursale(string fechaDesde, string fechaHasta);
        Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ListadoUsuarios(string fechaDesde, string fechaHasta);
        Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNo(int UsuarioNo);
        Task<ResourceResponseDto<UsuarioObjetoDto>> ObtenerporIdUsuarioNo(int UsuarioNo);
        Task<ResourceResponseDto<int>> UpdateUsuarioAsync(UsuarioObjetoDto parameter);


        Task<bool> CorreoExisteAsync(string correo);

        Task<bool> DocumentoExisteAsync(string numeroDocumento);

        Task<ResourceResponseDto<bool>> EliminarUsuarioAsync(int usuarioNo);


    }
}
