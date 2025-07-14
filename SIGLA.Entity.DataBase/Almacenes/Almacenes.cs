using SIGLA.Entity.DataBase.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Almacenes
{
    public partial class Almacenes
    {
        public int AlmacenNo { get; set; }
        public string NombreAlmacen { get; set; }
        public string Direccion { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaHoraCreacion { get; set; }
        public string UsuarioBaja { get; set; }
        public DateTime? FechaHoraBaja { get; set; }
        public bool Anulado { get; set; }
        public int SucursalNo { get; set; }
        public int UsuarioNo { get; set; }
        


    }
}
