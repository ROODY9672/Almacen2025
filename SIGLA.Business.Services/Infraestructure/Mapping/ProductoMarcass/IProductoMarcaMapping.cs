using SIGLA.Business.Dto.ProductoCategoriasss;
using SIGLA.Business.Dto.ProductoMarcasss;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Entity.DataBase.ProductoCategoria;
using SIGLA.Entity.DataBase.ProductoMarca;
using SIGLA.Entity.DataBase.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoMarcass
{
    public interface IProductoMarcaMapping
    {
        ProductoMarca ToEntity(ProductoMarcaCreacionDto dto);
        ProductoMarcaObjetoDto toDto(ProductoMarca dto);

    }
}
