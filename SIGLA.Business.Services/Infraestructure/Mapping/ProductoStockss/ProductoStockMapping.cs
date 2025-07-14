using SIGLA.Business.Dto.ProductoStocksss;
using SIGLA.Entity.DataBase.ProductoStock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoStockss
{


    public class ProductoStockMapping : IProductoStockMapping
    {


        public ProductoStock ToEntity(ProductoStockCreacionDto dto)
        {
            if (dto == null)
            {
                return new ProductoStock();
            }

            return new ProductoStock
            {
                ProductoStockNo = dto.ProductoStockNo,
                ProductoNo = dto.ProductoNo,
                AlmacenNo = dto.AlmacenNo,
                Stock = dto.Stock,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ?? DateTime.Now,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }







    }
}
