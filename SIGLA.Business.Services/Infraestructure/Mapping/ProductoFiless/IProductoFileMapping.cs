using SIGLA.Business.Dto.ProductoFilesss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Entity.DataBase.ProductoFile;
using SIGLA.Entity.DataBase.SucursalesFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoFiless
{
    public interface   IProductoFileMapping
    {
        ProductoFile ToEntity(ProductoFileCreacionDto dto);

    }
}
