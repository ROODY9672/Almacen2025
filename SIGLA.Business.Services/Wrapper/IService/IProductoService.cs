using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Productosss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IProductoService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoCreacionDto dto);

    }
}
