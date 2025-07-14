using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.CompraDetallesss;
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

namespace SIGLA.Business.Services.Wrapper.Service
{
    public class CompraDetalleService : BaseServices, ICompraDetalleService

    {


        private readonly IMappingGeneric _mapping;

        public CompraDetalleService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(CompraDetalleCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.CompraDetalleMapping.ToEntity(parameter);

                param.Add("@CompraNo", entity.CompraNo);
                param.Add("@ProductoNo", entity.ProductoNo);
                param.Add("@Cantidad", entity.Cantidad);
                param.Add("@PrecioUnitario", entity.PrecioUnitario);
                param.Add("@Subtotal", entity.Subtotal);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
             
                param.Add("@CompraDetalleNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var compraDetalleNo = await this._unit.CompraDetalleRepository.ExecRecordScopeAsync(
                    command: CompraDetalle.ToInsert,
                    param: param,
                    scope: "@CompraDetalleNo",
                    commandType: CommandType.Text);

                if (compraDetalleNo > 0)
                {
                    result.Success = true;
                    result.Data = compraDetalleNo;
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
