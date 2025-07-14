using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Ventas
{
    public partial class Ventas
    {
        public int VentaNo { get; set; }
        public string NumeroVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int ClienteNo { get; set; }
        public string Observaciones { get; set; }
        public string EstadoVenta { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // Nullable por si no se ha dado de baja
        public bool Anulado { get; set; }
    }
}
