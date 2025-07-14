using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Almacenessss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.IService
{
    public interface IAlmacenesService
    {

        Task<ResourceResponseDto<int>> RegisterAsync(AlmacenesCreacionDto dto);
        Task<ResourceResponseDto<IEnumerable<AlmacenesColeccionDto>>> ListadoAlmacenes(string fechaDesde, string fechaHasta,int sucursalNo);



    }
}
