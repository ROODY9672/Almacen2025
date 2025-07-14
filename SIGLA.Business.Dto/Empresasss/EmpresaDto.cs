using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Empresasss
{
    public class EmpresaDto
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public List<UsuariosColeccionDto> lstCentroControl { get; set; }

    }
}
