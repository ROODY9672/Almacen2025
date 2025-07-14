using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.UsuariosFilessss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Usuariossss
{
    public class UsuarioYImageViewModel
    {
        public UsuariosCreacionDto centroControl { get; set; }

        public UsuariosFileCreacionDto lstImageArchivo { get; set; }
        //public string VehiculoNoValue { get; set; }
        public IFormFile[] fileInput  { get; set; }

        // Agregado: lista de sucursales
        public List<SucursalesColeccionDto> Sucursales { get; set; }

    }
}
