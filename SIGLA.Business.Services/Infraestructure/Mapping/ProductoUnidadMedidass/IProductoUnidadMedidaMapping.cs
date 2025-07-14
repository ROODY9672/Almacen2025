using SIGLA.Business.Dto.ProductoMarcasss;
using SIGLA.Business.Dto.ProductoUnidadMedidasss;
using SIGLA.Entity.DataBase.ProductoMarca;
using SIGLA.Entity.DataBase.ProductoUnidadMedida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoUnidadMedidass
{
   public interface IProductoUnidadMedidaMapping
    {
        ProductoUnidadMedida ToEntity(ProductoUnidadMedidaCreacionDto dto);

    }
}
