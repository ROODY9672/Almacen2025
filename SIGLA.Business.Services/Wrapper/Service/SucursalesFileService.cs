using Dapper;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.UsuariosFile;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Entity.DataBase.SucursalesFile;

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class SucursalesFileService : BaseServices, ISucursalesFileService

    {


        private readonly IMappingGeneric _mapping;

        public SucursalesFileService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(SucursalesFileCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.SucursalesFileMapping.ToEntity(parameter); // Mapea DTO a entidad

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@FlagTipoFoto", entity.FlagTipoFoto);
                param.Add("@NombreDocumento", entity.NombreDocumento);
                param.Add("@NombreArchivo", entity.NombreArchivo);
                param.Add("@ContentType", entity.ContentType);
                param.Add("@Data", entity.Data);

                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                param.Add("@SucursalNo", entity.SucursalNo);

                // Parámetro de salida
                param.Add("@SucursalesFileNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var SucursalesFileNo = await this._unit.SucursalesFileRepository.ExecRecordScopeAsync(
                    command: SucursalesFile.ToInsert,
                    param: param,
                    scope: "@SucursalesFileNo",
                    commandType: CommandType.Text);

                if (SucursalesFileNo > 0)
                {
                    result.Success = true;
                    result.Data = SucursalesFileNo;
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




        public async Task<ResourceResponseDto<IEnumerable<SucursalesFileColeccionDto>>> ListadoFotosFiltradoTodos(int id)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<SucursalesFileColeccionDto>>();

            try
            {
                param.Add("@SucursalNo", id);
                //param.Add("@TipoFotoNo", TipoFotoNo);
                var query = await this._unit.UsuariosFileRepository.PostRecordsAsync<SucursalesFile>(
                    command: SucursalesFile.ToSelectedTipoFotoTodos,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.SucursalesFileMapping.ToEnumerable(query);
                    }
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
