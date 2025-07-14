using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Usuariossss
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "El correo es obligatorio.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Clave { get; set; }

        public bool Recordarme { get; set; }

    }
}
