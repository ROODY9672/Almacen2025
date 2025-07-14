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
    public class ProductoMarcaMapping : IProductoMarcaMapping
    {

        public ProductoMarca ToEntity(ProductoMarcaCreacionDto dto)
        {
            if (dto == null)
            {
                return new ProductoMarca();
            }

            return new ProductoMarca
            {
                ProductoMarcaNo = dto.ProductoMarcaNo,
                Descripcion = dto.Descripcion,

                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion, // puedes omitirlo si usas GETDATE() en SQL
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }




        public ProductoMarcaObjetoDto toDto(ProductoMarca dto)
        {
            return new ProductoMarcaObjetoDto()
            {
                ProductoMarcaNo = dto.ProductoMarcaNo,
                Descripcion = dto.Descripcion,
               
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
        
            };
        }








    }
}
