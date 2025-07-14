using SIGLA.Business.Dto.ProductoFilesss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Entity.DataBase.ProductoFile;
using SIGLA.Entity.DataBase.SucursalesFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.ProductoFiless
{
    public class ProductoFileMapping : IProductoFileMapping
    {
        public ProductoFile ToEntity(ProductoFileCreacionDto dto)
        {
            if (dto == null)
            {
                return new ProductoFile();
            }

            return new ProductoFile
            {
                ProductoFileNo = dto.ProductoFileNo,
                FlagTipoFoto = dto.FlagTipoFoto,
                NombreDocumento = dto.NombreDocumento,
                NombreArchivo = dto.NombreArchivo,
                ContentType = dto.ContentType,
                Data = dto.Data,
                Anulado = dto.Anulado,
                FechaHoraAnulado = dto.FechaHoraAnulado,
                UsuarioAnulado = dto.UsuarioAnulado,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                ProductoNo = dto.ProductoNo
            };
        }








    }
}
