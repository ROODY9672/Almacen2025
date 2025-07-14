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
    public class UsuariosViewModelEditar
    {
        public UsuarioObjetoDto centroControl { get; set; }
        public List<SucursalesColeccionDto> Sucursales { get; set; }
        public IFormFile[] fileInput { get; set; }

        public List<int> SucursalesAsignadas { get; set; }  // ← Añade esto

    }
}
