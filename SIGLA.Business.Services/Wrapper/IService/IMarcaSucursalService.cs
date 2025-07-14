using SIGLA.Business.Dto.Comprassss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.MarcaSucursalsss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IMarcaSucursalService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(MarcaSucursalCreacionDto dto);
        Task<bool> ExisteRelacionAsync(int productoMarcaNo, int sucursalNo);

    }
}
