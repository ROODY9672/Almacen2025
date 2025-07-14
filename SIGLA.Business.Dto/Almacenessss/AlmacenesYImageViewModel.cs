using Microsoft.AspNetCore.Http;
using SIGLA.Business.Dto.AlmacenesFilesss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.Sucursalessss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto.Almacenessss
{
    public class AlmacenesYImageViewModel
    {
        public AlmacenesCreacionDto centroControl { get; set; }

        public AlmacenesFileCreacionDto lstImageArchivo { get; set; }
        //public string VehiculoNoValue { get; set; }
        public IFormFile[] fileInput { get; set; }
    }
}
