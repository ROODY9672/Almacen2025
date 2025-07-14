using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.UsuarioSucursalsss
{
    public class UsuariosPanelControlViewModel
    {
        public UsuarioObjetoDto centroControl { get; set; }
        //public List<SucursalesColeccionDto> Sucursales { get; set; }
        public IFormFile[] fileInput { get; set; }

        // POR esto:
        public List<UsuarioSucursalColeccionDto> Sucursales { get; set; }
    }
}
