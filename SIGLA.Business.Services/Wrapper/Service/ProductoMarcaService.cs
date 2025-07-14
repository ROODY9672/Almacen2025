using Dapper;
using SIGLA.Business.Dto.CompraDetallesss;
using SIGLA.Business.Dto;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.CompraDetalle;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIGLA.Business.Dto.ProductoMarcasss;
using SIGLA.Entity.DataBase.ProductoMarca;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Entity.DataBase.Sucursales;

namespace SIGLA.Business.Services.Wrapper.Service
{
   

        public class ProductoMarcaService : BaseServices, IProductoMarcaService

        {


            private readonly IMappingGeneric _mapping;

            public ProductoMarcaService(IUnitOfWork unit, IMappingGeneric mapping)
              : base(unit)
            {
                this._mapping = mapping;
            }



        public async Task<ResourceResponseDto<int>> RegisterAsync(ProductoMarcaCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProductoMarcaMapping.ToEntity(parameter);

                param.Add("@Descripcion", entity.Descripcion);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);

                param.Add("@ProductoMarcaNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var productoMarcaNo = await this._unit.ProductoMarcaRepository.ExecRecordScopeAsync(
                    command: ProductoMarca.ToInsert,
                    param: param,
                    scope: "@ProductoMarcaNo",
                    commandType: CommandType.Text);

                if (productoMarcaNo > 0)
                {
                    result.Success = true;
                    result.Data = productoMarcaNo;
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


    
        public async Task<ResourceResponseDto<ProductoMarcaObjetoDto>> BuscarPorNombreAsync(string Descripcion)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<ProductoMarcaObjetoDto>();

            try
            {
                param.Add("@Descripcion", Descripcion);

                var query = await this._unit.ProductoMarcaRepository.PostRecordAsync<ProductoMarca>(
                   command: ProductoMarca.ToSearchByDescripcion,
                   param: param,
                   commandType: CommandType.Text);

                if (query != null)
                {
                    result.Success = true;
                    result.Data = this._mapping.ProductoMarcaMapping.toDto(query);
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


















    }
}
