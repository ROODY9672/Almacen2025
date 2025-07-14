using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.AlmacenesFilesss
{
    public class AlmacenesFileCreacionDto
    {
        public int AlmacenesFileNo { get; set; }
        public string FlagTipoFoto { get; set; }
        public string NombreDocumento { get; set; }
        public string NombreArchivo { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public bool Anulado { get; set; }
        public DateTime? FechaHoraAnulado { get; set; }
        public string UsuarioAnulado { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public int AlmacenNo { get; set; }
    }
}
