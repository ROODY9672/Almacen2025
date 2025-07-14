using Dapper;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Usuarios;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.UsuariosFile;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class UsuariosFileService : BaseServices, IUsuariosFileService

    {


        private readonly IMappingGeneric _mapping;

        public UsuariosFileService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(UsuariosFileCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.UsuariosFileMapping.ToEntity(parameter); // Mapea DTO a entidad

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@FlagTipoFoto", entity.FlagTipoFoto);
                param.Add("@NombreDocumento", entity.NombreDocumento);
                param.Add("@NombreArchivo", entity.NombreArchivo);
                param.Add("@ContentType", entity.ContentType);
                param.Add("@Data", entity.Data);
        
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
           
                param.Add("@UsuarioNo", entity.UsuarioNo);

                // Parámetro de salida
                param.Add("@UsuariosFileNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var usuariosFileNo = await this._unit.UsuariosFileRepository.ExecRecordScopeAsync(
                    command: UsuariosFile.ToInsert,
                    param: param,
                    scope: "@UsuariosFileNo",
                    commandType: CommandType.Text);

                if (usuariosFileNo > 0)
                {
                    result.Success = true;
                    result.Data = usuariosFileNo;
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




        public async Task<ResourceResponseDto<IEnumerable<UsuariosFileColeccionDto>>> ListadoFotosFiltradoTodos(int id)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuariosFileColeccionDto>>();

            try
            {
                param.Add("@UsuarioNo", id);
                //param.Add("@TipoFotoNo", TipoFotoNo);
                var query = await this._unit.UsuariosFileRepository.PostRecordsAsync<UsuariosFile>(
                    command: UsuariosFile.ToSelectedTipoFotoTodos,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuariosFileMapping.ToEnumerable(query);
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






        public async Task<ResourceResponseDto<UsuariosFileColeccionDto>> ObtenerFotoPerfilAsync(int usuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<UsuariosFileColeccionDto>();

            try
            {
                param.Add("@UsuarioNo", usuarioNo);

                var query = await this._unit.UsuariosFileRepository.PostRecordsAsync<UsuariosFile>(
                    command: UsuariosFile.ToSelectedTipoFotoTodos,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null && query.Any())
                {
                    var primera = query.OrderBy(x => x.UsuariosFileNo).FirstOrDefault(); // Puedes ordenar por fecha si prefieres

                    if (primera != null)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuariosFileMapping.ToDto(primera);
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
