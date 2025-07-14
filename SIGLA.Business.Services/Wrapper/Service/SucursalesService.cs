using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Empresa;
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

    public class SucursalesService : BaseServices, ISucursalesService

    {


        private readonly IMappingGeneric _mapping;

        public SucursalesService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(SucursalesCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.SucursalesMapping.ToEntity(parameter); // Corregido: SucursalesMapping

                // Agregamos todos los parámetros esperados en el SQL
                param.Add("@NombreSucursal", entity.NombreSucursal);
                param.Add("@Direccion", entity.Direccion);
                param.Add("@Telefono", entity.Telefono);
                param.Add("@Correo", entity.Correo); 
                param.Add("@EmpresaNo", entity.EmpresaNo); 
                param.Add("@Sede", entity.Sede);  
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                param.Add("@SucursalNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var sucursalNo = await this._unit.SucursalesRepository.ExecRecordScopeAsync(
                    command: Sucursales.ToInsert,
                    param: param,
                    scope: "@SucursalNo",
                    commandType: CommandType.Text);

                if (sucursalNo > 0)
                {
                    result.Success = true;
                    result.Data = sucursalNo;
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




        public async Task<ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>> ListadoSucursales(string fechaDesde, string fechaHasta)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>();

            try
            {
                //var fechapreuba = "sasa";
                param.Add("@FechaDesde", fechaDesde);
                param.Add("@FechaHasta", fechaHasta);

                var query = await this._unit.SucursalesRepository.PostRecordsAsync<Sucursales>(
                    command: Sucursales.Tosp_spSucursalesList,
                    param: param,
                    commandType: CommandType.StoredProcedure);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.SucursalesMapping.ToEnumerable(query);
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






        public async Task<ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>> ListadoSucursalesComboBox()
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<SucursalesColeccionDto>>();

            try
            {
                //var fechapreuba = "sasa";
                //param.Add("@FechaDesde", null);
                //param.Add("@FechaHasta", fechaHasta);

                var query = await this._unit.SucursalesRepository.PostRecordsAsync<Sucursales>(
                    command: Sucursales.To_Selected,
                    param: param,
                    commandType: CommandType.Text);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.SucursalesMapping.ToEnumerable(query);
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





        public async Task<ResourceResponseDto<SucursalesObjetoDto>> ObtenerporIdSucursalNo(int SucursalNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<SucursalesObjetoDto>();

            try
            {
                param.Add("@SucursalNo", SucursalNo);

                var query = await this._unit.UsuariosRepository.PostRecordAsync<Sucursales>(
                   command: Sucursales.ToObtenerSucursal,
                   param: param,
                   commandType: CommandType.Text);

                if (query != null)
                {
                    result.Success = true;
                    result.Data = this._mapping.SucursalesMapping.toDto(query);
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





        public async Task<ResourceResponseDto<int>> UpdateSucursalesAsync(SucursalesObjetoDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var usuario = this._mapping.SucursalesMapping.ToEntityUpdate(parameter);
                if (usuario != null)
                {
                    param.Add("@SucursalNo", usuario.SucursalNo, DbType.Int32);
                    param.Add("@NombreSucursal", usuario.NombreSucursal );
                    param.Add("@Direccion", usuario.Direccion);
                    param.Add("@Telefono", usuario.Telefono);
                    param.Add("@Correo", usuario.Correo);

                    // Ejecutando en BD
                    var rowAffect = await this._unit.SucursalesRepository.ExecRecordScopeAsync(
                        command: Sucursales.ToUpdate, // Debe tener un UPDATE con todos los campos correspondientes
                        param: param,
                        scope: "@SucursalNo",
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







    }
}
