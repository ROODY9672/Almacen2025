using SIGLA.Business.Dto.ProductoStocksss;
using SIGLA.Entity.DataBase.ProductoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoStockss
{
    public interface IProductoStockMapping
    {
        ProductoStock ToEntity(ProductoStockCreacionDto dto);

    }
}
