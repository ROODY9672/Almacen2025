using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoStock
{
    public partial class ProductoStock
    {
        public int ProductoStockNo { get; set; }
        public int ProductoNo { get; set; }
        public int? AlmacenNo { get; set; }
        public decimal? Stock { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // Nullable porque puede ser null si no se dio de baja
        public bool Anulado { get; set; }
    }
}
