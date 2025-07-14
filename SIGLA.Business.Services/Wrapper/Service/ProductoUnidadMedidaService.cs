using Dapper;
using SIGLA.Business.Dto.Clientessss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Clientes;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoUnidadMedidasss;
using SIGLA.Entity.DataBase.ProductoUnidadMedida;

namespace SIGLA.Business.Services.Wrapper.Service
{
 
        public class ProductoUnidadMedidaService : BaseServices, IProductoUnidadMedidaService

        {

            private readonly IMappingGeneric _mapping;

            public ProductoUnidadMedidaService(IUnitOfWork unit, IMappingGeneric mapping)
              : base(unit)
            {
                this._mapping = mapping;
            }



            public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoUnidadMedidaCreacionDto parameter)
            {
                var param = new DynamicParameters();
                var result = new ResourceResponseDto<int>();

                try
                {
                    var entity = this._mapping.ProductoUnidadMedidaMapping.ToEntity(parameter);

                    param.Add("@Descripcion", entity.Descripcion); 
                    param.Add("@Codigo", entity.Codigo);  
                    param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                    param.Add("@ProductoUnidadMedidaNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                    var productoUnidadMedidaNo = await this._unit.ProductoUnidadMedidaRepository.ExecRecordScopeAsync(
                        command: ProductoUnidadMedida.ToInsert,
                        param: param,
                        scope: "@ProductoUnidadMedidaNo",
                        commandType: CommandType.Text);

                    if (productoUnidadMedidaNo > 0)
                    {
                        result.Success = true;
                        result.Data = productoUnidadMedidaNo;
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
