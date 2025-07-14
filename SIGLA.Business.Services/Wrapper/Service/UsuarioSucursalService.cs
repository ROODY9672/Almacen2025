using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.Usuarios;
using SIGLA.Entity.DataBase.UsuarioSucursal;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class UsuarioSucursalService : BaseServices, IUsuarioSucursalService

    {


        private readonly IMappingGeneric _mapping;

        public UsuarioSucursalService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }

        public async Task<ResourceResponseDto<int>> RegisterAsync(UsuarioSucursalCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.UsuarioSucursalMapping.ToEntity(parameter); // Asegúrate de tener este mapeo correcto

                // Agregar parámetros requeridos
                param.Add("@UsuarioNo", entity.UsuarioNo);
                param.Add("@SucursalNo", entity.SucursalNo);
                param.Add("@EsPrincipal", entity.EsPrincipal);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
                param.Add("@UsuarioSucursalNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var usuarioSucursalId = await this._unit.UsuarioSucursalRepository.ExecRecordScopeAsync(
                    command: UsuarioSucursal.ToInsert,
                    param: param,
                    scope: "@UsuarioSucursalNo",
                    commandType: CommandType.Text);

                if (usuarioSucursalId > 0)
                {
                    result.Success = true;
                    result.Data = usuarioSucursalId;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = "No se pudo registrar el usuario-sucursal.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }





        public async Task<ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNo(int UsuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>();

            try
            {
                param.Add("@UsuarioNo", UsuarioNo);

                var query = await this._unit.UsuarioSucursalRepository.PostRecordsAsync<UsuarioSucursal>(
                    command: UsuarioSucursal.ToObtenerUsuarioSucursalXUsuarioNo,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuarioSucursalMapping.ToEnumerable(query);
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






        public async Task<ResourceResponseDto<bool>> EliminarSucursalesPorUsuario(int usuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<bool>();

            try
            {
                param.Add("@UsuarioNo", usuarioNo);

                var filasAfectadas = await this._unit.UsuarioSucursalRepository.ExecRecordAsync(
                    command: UsuarioSucursal.ToEliminarSucursalesPorUsuario,
                    param: param,
                    commandType: CommandType.Text);

                result.Success = filasAfectadas >= 0;
                result.Data = result.Success;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.Message;
                result.Data = false;
            }
            finally
            {
                param = null;
            }

            return result;
        }





        public async Task<ResourceResponseDto<bool>> EliminarAsync(int UsuarioNo)
        {
            var result = new ResourceResponseDto<bool>();
            var param = new DynamicParameters();
            param.Add("@UsuarioNo", UsuarioNo);

            try
            {
                var filasAfectadas = await _unit.UsuarioSucursalRepository.ExecRecordAsync(
                    command: UsuarioSucursal.ToEliminarUsuarioSucursal,
                    param: param,
                    commandType: CommandType.Text);

                result.Success = filasAfectadas > 0;
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







        public async Task<ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>> ObtenerUsuariosConSucursalesXUsuarioNoDetalle(int UsuarioNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<UsuarioSucursalColeccionDto>>();

            try
            {
                param.Add("@UsuarioNo", UsuarioNo);

                var query = await this._unit.UsuarioSucursalRepository.PostRecordsAsync<UsuarioSucursal>(
                    command: UsuarioSucursal.ToObtenerUsuarioSucursalXUsuarioNoDetalle,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.UsuarioSucursalMapping.ToEnumerable(query);
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
