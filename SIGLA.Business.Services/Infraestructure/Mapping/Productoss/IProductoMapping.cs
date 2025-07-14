using SIGLA.Business.Dto.Productosss;
using SIGLA.Entity.DataBase.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Productoss
{
    public interface IProductoMapping
    {
        Producto ToEntity(ProductoCreacionDto dto);

    }
}
