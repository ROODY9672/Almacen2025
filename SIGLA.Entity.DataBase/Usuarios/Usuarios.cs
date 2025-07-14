using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Usuarios
{
    public partial class Usuarios
    {
        public int UsuarioNo { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string ClaveHash { get; set; }
        public int SucursalNo { get; set; }
        public string Rol { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroDocumento { get; set; }
        public string Sexo { get; set; }



        //
        public string USUARIOS_NombreUsuario { get; set; }
        public string USUARIOS_ApellidoPaterno { get; set; }
        public string USUARIOS_ApellidoMaterno { get; set; }
        public string USUARIOS_NumeroDocumento { get; set; }
        public string USUARIOS_Rol { get; set; }
        public string USUARIOS_Correo { get; set; }
        public string SUCURSALES_NombreSucursal { get; set; }
        public string SUCURSALES_Direccion { get; set; }
        public string SUCURSALES_Telefono { get; set; }

        public bool? SUCURSALES_Sede { get; set; }

        public int UsuarioSucursalNo { get; set; }
        public bool? EsPrincipal { get; set; }



    }
}
