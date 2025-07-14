using Dapper;
using SIGLA.Business.Dto.ProductoStocksss;
using SIGLA.Business.Dto;
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
using SIGLA.Business.Dto.ProductoCategoriasss;
using SIGLA.Entity.DataBase.ProductoCategoria;

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class ProductoCategoriaService : BaseServices, IProductoCategoriaService

    {


        private readonly IMappingGeneric _mapping;

        public ProductoCategoriaService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }

        public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoCategoriaCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProductoCategoriaMapping.ToEntity(parameter);

                param.Add("@Descripcion", entity.Descripcion);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                param.Add("@ProductoCategoriaNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var productoCategoriaNo = await this._unit.ProductoCategoriaRepository.ExecRecordScopeAsync(
                    command: ProductoCategoria.ToInsert,
                    param: param,
                    scope: "@ProductoCategoriaNo",
                    commandType: CommandType.Text);

                if (productoCategoriaNo > 0)
                {
                    result.Success = true;
                    result.Data = productoCategoriaNo;
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
