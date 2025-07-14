using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.ProductoStocksss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.ProductoStock;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class ProductoStockService : BaseServices, IProductoStockService

    {


        private readonly IMappingGeneric _mapping;

        public ProductoStockService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoStockCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProductoStockMapping.ToEntity(parameter);

                param.Add("@ProductoNo", entity.ProductoNo);
                param.Add("@AlmacenNo", entity.AlmacenNo);
                param.Add("@Stock", entity.Stock);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
            

                param.Add("@ProductoStockNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var productoStockNo = await this._unit.ProductoStockRepository.ExecRecordScopeAsync(
                    command: ProductoStock.ToInsert,
                    param: param,
                    scope: "@ProductoStockNo",
                    commandType: CommandType.Text);

                if (productoStockNo > 0)
                {
                    result.Success = true;
                    result.Data = productoStockNo;
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
