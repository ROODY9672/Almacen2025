using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoFilesss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public  interface IProductoFileService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProductoFileCreacionDto dto);

    }
}
