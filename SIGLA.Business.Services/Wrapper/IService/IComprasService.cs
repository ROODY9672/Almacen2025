using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Comprassss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IComprasService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ComprasCreacionDto dto);

    }
}
