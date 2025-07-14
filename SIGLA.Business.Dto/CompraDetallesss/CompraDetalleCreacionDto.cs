using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.CompraDetallesss
{
    public class CompraDetalleCreacionDto
    {
        public int CompraDetalleNo { get; set; }
        public int CompraNo { get; set; }
        public int ProductoNo { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Subtotal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // Nullable si puede ser null
        public bool Anulado { get; set; }
    }
}
