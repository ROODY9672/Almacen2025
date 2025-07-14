using Dapper;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.SucursalesFile;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoFilesss;
using SIGLA.Entity.DataBase.ProductoFile;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class ProductoFileService : BaseServices, IProductoFileService

    {


        private readonly IMappingGeneric _mapping;

        public ProductoFileService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoFileCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProductoFileMapping.ToEntity(parameter); // Mapea DTO a entidad

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@FlagTipoFoto", entity.FlagTipoFoto);
                param.Add("@NombreDocumento", entity.NombreDocumento);
                param.Add("@NombreArchivo", entity.NombreArchivo);
                param.Add("@ContentType", entity.ContentType);
                param.Add("@Data", entity.Data);

                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
                param.Add("@ProductoNo", entity.ProductoNo);

                // Parámetro de salida
                param.Add("@ProductoFileNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var productoFileNo = await this._unit.ProductoFileRepository.ExecRecordScopeAsync(
                    command: ProductoFile.ToInsert,
                    param: param,
                    scope: "@ProductoFileNo",
                    commandType: CommandType.Text);

                if (productoFileNo > 0)
                {
                    result.Success = true;
                    result.Data = productoFileNo;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }
            finally
            {
                param = null;
            }

            return result;
        }














    }
}
