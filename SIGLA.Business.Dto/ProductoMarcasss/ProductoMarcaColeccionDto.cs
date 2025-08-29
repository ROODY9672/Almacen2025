using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.ProductoMarcasss
{
    public class ProductoMarcaColeccionDto
    {
        public int ProductoMarcaNo { get; set; }
        public string Descripcion { get; set; }
        public string UsuarioCreacion { get; set; }
        public string  FechaHoraCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaHoraModificacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }
        public int MarcaSucursalId { get; set; }
        public int SucursalNo { get; set; }

    }
}
