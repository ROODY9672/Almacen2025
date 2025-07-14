using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.AlmacenesFilesss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IAlmacenesFileService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(AlmacenesFileCreacionDto dto);

    }
}
