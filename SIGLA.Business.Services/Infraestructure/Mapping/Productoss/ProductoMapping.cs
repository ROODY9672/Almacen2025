using SIGLA.Business.Dto.Productosss;
using SIGLA.Entity.DataBase.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Productoss
{
    public class ProductoMapping : IProductoMapping
    {



        public Producto ToEntity(ProductoCreacionDto dto)
        {
            if (dto == null)
            {
                return new Producto();
            }

            return new Producto
            {
                ProductoNo = dto.ProductoNo,
                CodigoProducto = dto.CodigoProducto,
                NombreProducto = dto.NombreProducto,
                Descripcion = dto.Descripcion,
                UnidadMedida = dto.UnidadMedida,
                PrecioCosto = dto.PrecioCosto,
                PrecioVenta = dto.PrecioVenta,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion, // puedes omitirlo si usas GETDATE() en SQL
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }

    }
}
