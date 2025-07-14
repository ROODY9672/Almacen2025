using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Comprassss
{
    public class ComprasCreacionDto
    {
        public int CompraNo { get; set; }
        public string NumeroCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public int? ProveedorNo { get; set; }
        public string Observaciones { get; set; }
        public string EstadoCompra { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // Nullable por si aún no hay baja
        public bool Anulado { get; set; }
    }
}
