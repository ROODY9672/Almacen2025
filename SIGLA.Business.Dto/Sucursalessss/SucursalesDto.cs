using SIGLA.Business.Dto.Usuariossss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Sucursalessss
{
    public class SucursalesDto
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public List<SucursalesColeccionDto> lstCentroControl { get; set; }

    }
}
