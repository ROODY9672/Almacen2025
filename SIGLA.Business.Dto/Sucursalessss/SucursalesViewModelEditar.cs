using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Sucursalessss
{
    public class SucursalesViewModelEditar
    {
        public SucursalesObjetoDto centroControl { get; set; }
        //public List<SucursalesColeccionDto> Sucursales { get; set; }
        public IFormFile[] fileInput { get; set; }

        //public List<int> SucursalesAsignadas { get; set; }   


    }
}
