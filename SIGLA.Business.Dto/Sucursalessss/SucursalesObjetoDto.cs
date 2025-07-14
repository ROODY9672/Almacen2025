using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Sucursalessss
{
    public class SucursalesObjetoDto
    {
        public int SucursalNo { get; set; }
        public string NombreSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }
        public int EmpresaNo { get; set; }

        public string EMPRESA_RazonSocial { get; set; }

        public string EMPRESA_NumRuc { get; set; }

        public string EMPRESA_Direccion { get; set; }

        public string EMPRESA_Telefono1 { get; set; }
    }
}
