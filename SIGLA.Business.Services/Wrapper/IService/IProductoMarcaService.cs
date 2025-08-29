using SIGLA.Business.Dto.Clientessss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoMarcasss;

namespace SIGLA.Business.Services.Wrapper.IService
{
   public interface IProductoMarcaService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoMarcaCreacionDto dto);
        Task<ResourceResponseDto<ProductoMarcaObjetoDto>> BuscarPorNombreAsync(string Descripcion);
        Task<ResourceResponseDto<IEnumerable<ProductoMarcaColeccionDto>>> ListadoProductoMarca(string fechaDesde, string fechaHasta, int sucursalNo);

    }
}
