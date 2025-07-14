using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.UsuarioSucursalsss
{
    public class UsuarioSucursalCreacionDto
    {
        public int UsuarioSucursalNo { get; set; }
        public int UsuarioNo { get; set; }
        public int SucursalNo { get; set; }
        public bool? EsPrincipal { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaHoraModificacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }
    }
}
