using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Ventassss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
  public  interface IVentasService
    {
        Task<ResourceResponseDto<int>> RegisterAsync(VentasCreacionDto dto);

    }
}
