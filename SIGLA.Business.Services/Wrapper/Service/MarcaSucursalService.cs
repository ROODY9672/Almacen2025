using Dapper;
using SIGLA.Business.Dto.Productosss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Producto;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.MarcaSucursalsss;
using SIGLA.Entity.DataBase.MarcaSucursal;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class MarcaSucursalService : BaseServices, IMarcaSucursalService

    {


        private readonly IMappingGeneric _mapping;

        public MarcaSucursalService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(MarcaSucursalCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.MarcaSucursalMapping.ToEntity(parameter);

                // Agregar todos los parámetros necesarios
                param.Add("@ProductoMarcaNo", entity.ProductoMarcaNo);
                param.Add("@SucursalNo", entity.SucursalNo);


                param.Add("@MarcaSucursalId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var MarcaSucursalId = await this._unit.MarcaSucursalRepository.ExecRecordScopeAsync(
                    command: MarcaSucursal.ToInsert,
                    param: param,
                    scope: "@MarcaSucursalId",
                    commandType: CommandType.Text);

                if (MarcaSucursalId > 0)
                {
                    result.Success = true;
                    result.Data = MarcaSucursalId;
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



        public async Task<bool> ExisteRelacionAsync(int productoMarcaNo, int sucursalNo)
        {
            var param = new DynamicParameters();
            param.Add("@ProductoMarcaNo", productoMarcaNo);
            param.Add("@SucursalNo", sucursalNo);

            try
            {
                var result = await _unit.MarcaSucursalRepository.ExecScalarAsync(
                    MarcaSucursal.ToExistMarcaSucursal,
                    param,
                    CommandType.Text);


                return result == 1;
            }
            catch
            {
                return false;
            }
        }









    }
}
