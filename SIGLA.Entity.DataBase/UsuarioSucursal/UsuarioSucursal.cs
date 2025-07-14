using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.UsuarioSucursal
{
    public partial class UsuarioSucursal
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

        public string SUCURSALES_NombreSucursal { get; set; }
        public string SUCURSALES_Direccion { get; set; }
        public string SUCURSALES_Telefono { get; set; }
        public string SUCURSALES_Correo { get; set; }
        public bool? SUCURSALES_Sede { get; set; }


        
        public string EMPRESA_RazonSocial { get; set; }
        public string EMPRESA_NombreComercial { get; set; }
        public string EMPRESA_NumRuc { get; set; }
        public string EMPRESA_Direccion { get; set; }
        public string EMPRESA_Telefono1 { get; set; }
        public string EMPRESA_Telefono2 { get; set; }
        public string EMPRESA_Correo { get; set; }
    }
}
