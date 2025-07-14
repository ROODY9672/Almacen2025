using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.VentasDetallesss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.VentasDetalle;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class VentasDetalleService : BaseServices, IVentasDetalleService

    {


        private readonly IMappingGeneric _mapping;

        public VentasDetalleService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }

        public async Task<ResourceResponseDto<int>> RegisterAsync(VentasDetalleCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.VentasDetalleMapping.ToEntity(parameter); // Corrección: VentasDetalleMapping

                // Agregar todos los parámetros requeridos por el ToInsert
                param.Add("@VentaNo", entity.VentaNo);
                param.Add("@ProductoNo", entity.ProductoNo);
                param.Add("@Cantidad", entity.Cantidad);
                param.Add("@PrecioUnitario", entity.PrecioUnitario);
                param.Add("@Subtotal", entity.Subtotal);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
               
                param.Add("@VentaDetalleId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var ventaDetalleId = await this._unit.VentasDetalleRepository.ExecRecordScopeAsync(
                    command: VentasDetalle.ToInsert,
                    param: param,
                    scope: "@VentaDetalleId",
                    commandType: CommandType.Text);

                if (ventaDetalleId > 0)
                {
                    result.Success = true;
                    result.Data = ventaDetalleId;
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
