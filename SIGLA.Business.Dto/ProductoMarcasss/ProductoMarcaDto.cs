using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.ProductoMarcasss
{
    public class ProductoMarcaDto
    {
        public string FechaDesde { get; set; }
        public string FechaHasta { get; set; }
        public List<ProductoMarcaColeccionDto> lstCentroControl { get; set; }
    }
}
