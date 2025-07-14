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
using SIGLA.Business.Dto.AlmacenesFilesss;
using SIGLA.Entity.DataBase.AlmacenesFile;

namespace SIGLA.Business.Services.Wrapper.Service
{
    public class AlmacenesFileService : BaseServices, IAlmacenesFileService

    {


        private readonly IMappingGeneric _mapping;

        public AlmacenesFileService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(AlmacenesFileCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.AlmacenesFileMapping.ToEntity(parameter); // Mapea DTO a entidad

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@FlagTipoFoto", entity.FlagTipoFoto);
                param.Add("@NombreDocumento", entity.NombreDocumento);
                param.Add("@NombreArchivo", entity.NombreArchivo);
                param.Add("@ContentType", entity.ContentType);
                param.Add("@Data", entity.Data);

                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                param.Add("@AlmacenNo", entity.AlmacenNo);

                // Parámetro de salida
                param.Add("@AlmacenesFileNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var AlmacenesFileNo = await this._unit.AlmacenesFileRepository.ExecRecordScopeAsync(
                    command: AlmacenesFile.ToInsert,
                    param: param,
                    scope: "@AlmacenesFileNo",
                    commandType: CommandType.Text);

                if (AlmacenesFileNo > 0)
                {
                    result.Success = true;
                    result.Data = AlmacenesFileNo;
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
