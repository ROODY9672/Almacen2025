using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Business.Dto.ProductoCategoriasss;
using SIGLA.Entity.DataBase.Almacenes;
using SIGLA.Entity.DataBase.ProductoCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoCategoriass
{
    public interface IProductoCategoriaMapping
    {
        ProductoCategoria ToEntity(ProductoCategoriaCreacionDto dto);

    }
}
