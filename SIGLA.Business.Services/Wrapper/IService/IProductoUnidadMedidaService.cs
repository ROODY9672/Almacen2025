using SIGLA.Business.Dto.CompraDetallesss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoUnidadMedidasss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IProductoUnidadMedidaService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoUnidadMedidaCreacionDto dto);

    }
}
