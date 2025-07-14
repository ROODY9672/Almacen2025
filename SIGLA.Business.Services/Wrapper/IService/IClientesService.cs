using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Clientessss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IClientesService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(ClientesCreacionDto dto);

    }
}
