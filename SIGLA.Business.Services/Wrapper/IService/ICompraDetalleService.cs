using SIGLA.Business.Dto;
using SIGLA.Business.Dto.CompraDetallesss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface ICompraDetalleService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(CompraDetalleCreacionDto dto);

    }
}
