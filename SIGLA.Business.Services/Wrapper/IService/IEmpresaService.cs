using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.Empresasss;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IEmpresaService
    {
        Task<ResourceResponseDto<EmpresaObjetoDto>> ObtenerEmpresaObjetoDto();

    }
}
