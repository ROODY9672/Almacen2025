using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto.SucursalesFilesss;
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Sucursalessss
{
    public class SucursalYImageViewModel
    {
        public SucursalesCreacionDto centroControl { get; set; }

        public SucursalesFileCreacionDto lstImageArchivo { get; set; }
        //public string VehiculoNoValue { get; set; }
        public IFormFile[] fileInput { get; set; }
        // Nuevos campos para mostrar en la vista
        public int EmpresaNo { get; set; }

        public string RazonSocial { get; set; }
        public string NumRuc { get; set; }

    }
}
