using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Productosss;
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

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class ProductoService : BaseServices, IProductoService

    {


        private readonly IMappingGeneric _mapping;

        public ProductoService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProductoMapping.ToEntity(parameter);

                // Agregar todos los parámetros necesarios
                param.Add("@CodigoProducto", entity.CodigoProducto);
                param.Add("@NombreProducto", entity.NombreProducto);
                param.Add("@Descripcion", entity.Descripcion);
                param.Add("@UnidadMedida", entity.UnidadMedida);
                param.Add("@PrecioCosto", entity.PrecioCosto);
                param.Add("@PrecioVenta", entity.PrecioVenta);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
             
                param.Add("@ProductoNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var ProductoNo = await this._unit.ProductoStockRepository.ExecRecordScopeAsync(
                    command: Producto.ToInsert,
                    param: param,
                    scope: "@ProductoNo",
                    commandType: CommandType.Text);

                if (ProductoNo > 0)
                {
                    result.Success = true;
                    result.Data = ProductoNo;
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
