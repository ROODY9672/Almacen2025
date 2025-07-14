using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Proveedoressss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IProveedoresService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ProveedoresCreacionDto dto);

    }
}
