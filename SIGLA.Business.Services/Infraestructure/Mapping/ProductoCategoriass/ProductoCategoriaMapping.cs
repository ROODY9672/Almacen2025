using SIGLA.Business.Dto.ProductoCategoriasss;
using SIGLA.Business.Dto.Productosss;
using SIGLA.Entity.DataBase.Producto;
using SIGLA.Entity.DataBase.ProductoCategoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoCategoriass
{
    public class ProductoCategoriaMapping : IProductoCategoriaMapping
    {

        public ProductoCategoria ToEntity(ProductoCategoriaCreacionDto dto)
        {
            if (dto == null)
            {
                return new ProductoCategoria();
            }

            return new ProductoCategoria
            {
                ProductoCategoriaNo = dto.ProductoCategoriaNo,
                Descripcion = dto.Descripcion,
               
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion, // puedes omitirlo si usas GETDATE() en SQL
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }

       
    }
}
