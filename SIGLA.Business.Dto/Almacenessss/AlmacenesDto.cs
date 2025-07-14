using SIGLA.Business.Dto.Sucursalessss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Almacenessss
{
    public class AlmacenesDto
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public List<AlmacenesColeccionDto> lstCentroControl { get; set; }
    }
}
