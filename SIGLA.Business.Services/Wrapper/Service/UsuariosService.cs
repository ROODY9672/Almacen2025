using Dapper;
using Microsoft.Data.SqlClient;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.Usuarios;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class UsuariosService : BaseServices, IUsuariosService

    {


        private readonly IMappingGeneric _mapping;

        public UsuariosService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }

        public async Task<ResourceResponseDto<int>> RegisterAsync(UsuariosCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.UsuariosMapping.ToEntity(parameter); // Corrección: UsuariosMapping

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@NombreUsuario", entity.NombreUsuario);
                param.Add("@Correo", entity.Correo);
                param.Add("@ClaveHash", entity.ClaveHash);
                param.Add("@Rol", entity.Rol);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
           

                // Parámetro de salida
                param.Add("@UsuarioNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var usuarioNo = await this._unit.UsuariosRepository.ExecRecordScopeAsync(
                    command: Usuarios.ToInsert,
                    param: param,
                    scope: "@UsuarioNo",
                    commandType: CommandType.Text);

                if (usuarioNo > 0)
                {
                    result.Success = true;
                    result.Data = usuarioNo;
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


        public async Task<ResourceResponseDto<int>> RegisterUsuarioCompletoAsync(UsuariosCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.UsuariosMapping.ToEntity(parameter); // Corrección: UsuariosMapping

                // Agregar todos los parámetros requeridos por el script de inserción
                param.Add("@NombreUsuario", entity.NombreUsuario);
                param.Add("@Correo", entity.Correo);
                param.Add("@ClaveHash", entity.ClaveHash);
                param.Add("@Rol", entity.Rol);

                param.Add("@ApellidoPaterno", entity.ApellidoPaterno);
                param.Add("@ApellidoMaterno", entity.ApellidoMaterno);
                param.Add("@NumeroDocumento", entity.NumeroDocumento);
                param.Add("@Sexo", entity.Sexo);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);


                // Parámetro de salida
                param.Add("@UsuarioNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var usuarioNo = await this._unit.UsuariosRepository.ExecRecordScopeAsync(
                    command: Usuarios.ToInsertUsuarioCompleto,
                    param: param,
                    scope: "@UsuarioNo",
                    commandType: CommandType.Text);

                if (usuarioNo > 0)
                {
                    result.Success = true;
                    result.Data = usuarioNo;
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



        public async Task<ResourceResponseDto<UsuarioDto>> ValidarLoginAsync(UsuarioLoginDto dto)
        {
            var result = new ResourceResponseDto<UsuarioDto>();
            var param = new DynamicParameters();

            try
            {
                // Parametros que espera el SP
                param.Add("@Correo", dto.Correo);
                param.Add("@Clave", dto.Clave); // Aquí deberías enviar Clave ya hasheada si corresponde

                // Ejecutar el SP usando tu repositorio genérico
                var query = await this._unit.UsuariosRepository.PostRecordsAsync<UsuarioDto>(
                    command: "sp_ValidarUsuarioLogin", // nombre del procedimiento almacenado
                    param: param,
                    commandType: CommandType.StoredProcedure);

                var usuario = query?.FirstOrDefault();

                if (usuario != null)
                {
                    result.Success = true;
                    result.Data = usuario;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = "Correo o clave incorrectos.";
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


        //public async Task<UsuarioDto> ValidarLogin(UsuarioLoginDto dto)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@Correo", dto.Correo);
        //    param.Add("@Clave", dto.Clave);

        //    var result = await _unit.UsuariosRepository.PostRecordAsync<UsuarioDto>(
        //        command: "sp_ValidarLogin",
        //        param: param,
        //        commandType: CommandType.StoredProcedure);

        //    return result;
        //}


        public async Task<UsuarioDto> ValidarLogin(UsuarioLoginDto dto)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Correo", dto.Correo);
                param.Add("@Clave", dto.Clave);

                var result = await _unit.UsuariosRepository.PostRecordAsync<UsuarioDto>(
                    command: "sp_ValidarLogin",
                    param: param,
                    commandType: CommandType.StoredProcedure);

                return result;
            }
            catch (SqlException sqlEx)
            {
                // Errores relacionados con la base de datos
                // Puedes loguearlo o mapearlo a un DTO con mensaje de error si lo necesitas
                Console.WriteLine($"SQL Error: {sqlEx.Message}");
                throw new Exception("Error al conectar con la base de datos. Intenta nuevamente.");
            }
            catch (Exception ex)
            {
                // Errores generales
                Console.WriteLine($"Error: {ex.Message}");
                throw new Exception("Ocurrió un error al validar el usuario.");
            }
        }






        public async Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ListadoUsuariosConSucursale(string fechaDesde, string fechaHasta)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>();

            try
            {
                //var fechapreuba = "sasa";
                param.Add("@FechaDesde", fechaDesde);
                param.Add("@FechaHasta", fechaHasta);
                var query = await this._unit.UsuariosRepository.PostRecordsAsync<Usuarios>(
                    command: Usuarios.Tosp_sp_ObtenerUsuariosConSucursales,
                    param: param,
                    commandType: CommandType.StoredProcedure);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuariosMapping.ToEnumerable(query);
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





        public async Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ListadoUsuarios(string fechaDesde, string fechaHasta)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>();

            try
            {
                //var fechapreuba = "sasa";
                param.Add("@FechaDesde", fechaDesde);
                param.Add("@FechaHasta", fechaHasta);
                var query = await this._unit.UsuariosRepository.PostRecordsAsync<Usuarios>(
                    command: Usuarios.Tosp_sp_ObtenerUsuariosListado,
                    param: param,
                    commandType: CommandType.StoredProcedure);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuariosMapping.ToEnumerable(query);
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





        public async Task<ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNo(int UsuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuariosColeccionDto>>();

            try
            {
                param.Add("@UsuarioNo", UsuarioNo);

                var query = await this._unit.UsuariosRepository.PostRecordsAsync<Usuarios>(
                    command: Usuarios.Tosp_sp_ObtenerUsuariosConSucursalesXUsuarioNo,
                    param: param,
                    commandType: CommandType.StoredProcedure);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuariosMapping.ToEnumerable(query);
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



        public async Task<ResourceResponseDto<UsuarioObjetoDto>> ObtenerporIdUsuarioNo(int UsuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<UsuarioObjetoDto>();

            try
            {
                param.Add("@UsuarioNo", UsuarioNo);

                var query = await this._unit.UsuariosRepository.PostRecordAsync<Usuarios>(
                   command: Usuarios.ToObtenerUsuario,
                   param: param,
                   commandType: CommandType.Text);

                if (query != null)
                {
                    result.Success = true;
                    result.Data = this._mapping.UsuariosMapping.toDto(query);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.Data = null;
            }
            finally
            {
                param = null;
            }

            return result;
        }







        public async Task<ResourceResponseDto<int>> UpdateUsuarioAsync(UsuarioObjetoDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var usuario = this._mapping.UsuariosMapping.ToEntityUpdate(parameter);
                if (usuario != null)
                {
                    param.Add("@UsuarioNo", usuario.UsuarioNo, DbType.Int32);
                    param.Add("@NombreUsuario", usuario.NombreUsuario);
                    param.Add("@ApellidoPaterno", usuario.ApellidoPaterno);
                    param.Add("@ApellidoMaterno", usuario.ApellidoMaterno);
                    param.Add("@NumeroDocumento", usuario.NumeroDocumento);
                    param.Add("@Sexo", usuario.Sexo);
                    param.Add("@Rol", usuario.Rol);
                  

                    // Ejecutando en BD
                    var rowAffect = await this._unit.UsuariosRepository.ExecRecordScopeAsync(
                        command: Usuarios.ToUpdate, // Asegúrate que `Usuarios.ToUpdate` contenga el UPDATE SQL correcto
                        param: param,
                        scope: "@UsuarioNo",
                        commandType: CommandType.Text);

                    result.Success = rowAffect > 0;
                    result.Data = rowAffect;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.Data = 0;
            }
            finally
            {
                param = null;
            }

            return result;
        }





        public async Task<bool> CorreoExisteAsync(string correo)
        {
            var param = new DynamicParameters();
            param.Add("@Correo", correo);

            var result = await _unit.UsuariosRepository.PostRecordAsync<Usuarios>(
                command: Usuarios.ToVerificarCorreoExiste,
                param: param,
                commandType: CommandType.Text);

            return result != null;
        }

        public async Task<bool> DocumentoExisteAsync(string numeroDocumento)
        {
            var param = new DynamicParameters();
            param.Add("@NumeroDocumento", numeroDocumento);

            var result = await _unit.UsuariosRepository.PostRecordAsync<Usuarios>(
                command: Usuarios.ToVerificarDocumentoExiste,
                param: param,
                commandType: CommandType.Text);

            return result != null;
        }



        public async Task<ResourceResponseDto<bool>> EliminarUsuarioAsync(int usuarioNo)
        {
            var result = new ResourceResponseDto<bool>();
            var param = new DynamicParameters();
            param.Add("@UsuarioNo", usuarioNo);

            try
            {
                var filas = await _unit.UsuariosRepository.ExecRecordAsync(
                    command: Usuarios.ToEliminarUsuario,
                    param: param,
                    commandType: CommandType.Text);

                result.Success = filas > 0;
                result.Data = result.Success;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.Data = false;
            }

            return result;
        }


    }
}
