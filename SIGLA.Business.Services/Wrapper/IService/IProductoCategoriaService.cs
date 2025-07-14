using SIGLA.Business.Dto.CompraDetallesss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoCategoriasss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IProductoCategoriaService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoCategoriaCreacionDto dto);

    }
}
