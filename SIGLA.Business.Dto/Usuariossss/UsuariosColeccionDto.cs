using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Usuariossss
{
    public class UsuariosColeccionDto
    {
        public int UsuarioSucursalNo { get; set; }
        public int UsuarioNo { get; set; }
        public int SucursalNo { get; set; }
        public bool? EsPrincipal { get; set; }
        public string UsuarioCreacion { get; set; }
        public string FechaHoraCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public DateTime? FechaHoraModificacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }


        public string USUARIOS_NombreUsuario { get; set; }
        public string USUARIOS_ApellidoPaterno { get; set; }
        public string USUARIOS_ApellidoMaterno { get; set; }
        public string USUARIOS_NumeroDocumento { get; set; }
        public string USUARIOS_Rol { get; set; }
        public string USUARIOS_Correo { get; set; }
        public string SUCURSALES_NombreSucursal { get; set; }
        public string SUCURSALES_Direccion { get; set; }
        public string SUCURSALES_Telefono { get; set; }
        public string USUARIOS_Sexo { get; set; }
        public string SUCURSALES_Sede { get; set; }
        

    }
}
