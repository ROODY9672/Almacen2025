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
    public class ProductoUnidadMedidaMapping : IProductoUnidadMedidaMapping
    {

        public ProductoUnidadMedida ToEntity(ProductoUnidadMedidaCreacionDto dto)
        {
            if (dto == null)
            {
                return new ProductoUnidadMedida();
            }

            return new ProductoUnidadMedida
            {
                ProductoUnidadMedidaNo = dto.ProductoUnidadMedidaNo,
                Descripcion = dto.Descripcion,
                Codigo = dto.Codigo,

                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion, // puedes omitirlo si usas GETDATE() en SQL
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }


    }
}
