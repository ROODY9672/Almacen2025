using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Usuariossss
{
    public class UsuariosCreacionDto
    {
        public int UsuarioNo { get; set; }
        //public string NombreUsuario { get; set; }
        //public string Correo { get; set; }
        public string ClaveHash { get; set; }
        public int SucursalNo { get; set; }
        public string Rol { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }
        //public string Clave { get; set; } 
        // <- Agrega esta propiedad temporal para capturar el valor del formulario
        //public List<int> SucursalesSeleccionadas { get; set; }
        public List<int> SucursalesSeleccionadas { get; set; } = new List<int>();



        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        [DataType(DataType.Password)]
        public string Clave { get; set; }




        [Required(ErrorMessage = "Confirme su contraseña")]
        [DataType(DataType.Password)]
        [Compare("Clave", ErrorMessage = "Las contraseñas no coinciden")]
        public string  ConfirmarClave { get; set; }


        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string NumeroDocumento { get; set; }
        public string Sexo { get; set; }

        
    }
}
