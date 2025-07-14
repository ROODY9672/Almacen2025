using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Almacenes;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class AlmacenesService : BaseServices, IAlmacenesService

    {

        private readonly IMappingGeneric _mapping;

        public AlmacenesService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }




        public async Task<ResourceResponseDto<int>> RegisterAsync(AlmacenesCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.AlmacenesMapping.ToEntity(parameter);

                param.Add("@NombreAlmacen", entity.NombreAlmacen);
                param.Add("@Direccion", entity.Direccion);
                param.Add("@SucursalNo", entity.SucursalNo);
                param.Add("@UsuarioNo", entity.UsuarioNo);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
                param.Add("@AlmacenNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Ejecuta la inserción y obtiene el ID generado
                var almacenNo = await this._unit.AlmacenesRepository.ExecRecordScopeAsync(
                    command: Almacenes.ToInsert,
                    param: param,
                    scope: "@AlmacenNo",
                    commandType: CommandType.Text);

                if (almacenNo > 0)
                {
                    result.Success = true;
                    result.Data = almacenNo;
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




        public async Task<ResourceResponseDto<IEnumerable<AlmacenesColeccionDto>>> ListadoAlmacenes(string fechaDesde, string fechaHasta,int sucursalNo)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<IEnumerable<AlmacenesColeccionDto>>();

            try
            {
                //var fechapreuba = "sasa";
                param.Add("@FechaDesde", fechaDesde);
                param.Add("@FechaHasta", fechaHasta); 
                param.Add("@SucursalNo", sucursalNo);  

                var query = await this._unit.SucursalesRepository.PostRecordsAsync<Almacenes>(
                    command: Almacenes.Tosp_spAlmacenesList,
                    param: param,
                    commandType: CommandType.StoredProcedure);

                if (query != null)
                {
                    if (query.Count() > 0)
                    {
                        result.Success = true;
                        result.Data = this._mapping.AlmacenesMapping.ToEnumerable(query);
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
