using SIGLA.Business.Dto;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IUsuarioSucursalService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(UsuarioSucursalCreacionDto dto);
        Task<ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNo(int UsuarioNo);
        Task<ResourceResponseDto<bool>> EliminarSucursalesPorUsuario(int usuarioNo);
        Task<ResourceResponseDto<bool>> EliminarAsync(int UsuarioNo);
        Task<ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNoDetalle(int UsuarioNo);

    }
}
