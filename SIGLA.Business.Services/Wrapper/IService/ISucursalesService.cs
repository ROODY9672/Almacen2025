using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
   public interface ISucursalesService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(SucursalesCreacionDto dto);
        Task<ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>> ListadoSucursales(string fechaDesde, string fechaHasta);
        Task<ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>> ListadoSucursalesComboBox();
        Task<ResourceResponseDto<SucursalesObjetoDto>> ObtenerporIdSucursalNo(int SucursalNo);
        Task<ResourceResponseDto<int>> UpdateSucursalesAsync(SucursalesObjetoDto parameter);

    }
}
