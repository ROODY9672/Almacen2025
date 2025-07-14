using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.VentasDetallesss
{
    public class VentasDetalleCreacionDto
    {
        public int VentaDetalleId { get; set; }
        public int VentaNo { get; set; }
        public int ProductoNo { get; set; }
        public decimal? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Subtotal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // Nullable si aún no ha sido dado de baja
        public bool Anulado { get; set; }
    }
}
