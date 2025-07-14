using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Empresa
{
    public partial class Empresa
    {
        public int EmpresaNo { get; set; }
        public string RazonSocial { get; set; }
        public string NombreComercial { get; set; }
        public string NumRuc { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; } // nullable en caso de que no siempre tenga valor
        public bool Anulado { get; set; }
    }
}
