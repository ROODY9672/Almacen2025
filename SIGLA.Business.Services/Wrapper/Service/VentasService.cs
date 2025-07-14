using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Ventassss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Ventas;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class VentasService : BaseServices, IVentasService

    {


        private readonly IMappingGeneric _mapping;

        public VentasService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }

        public async Task<ResourceResponseDto<int>> RegisterAsync(VentasCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.VentasMapping.ToEntity(parameter); // Corregido: VentasMapping

                // Agregar todos los parámetros esperados
                param.Add("@NumeroVenta", entity.NumeroVenta);
                param.Add("@FechaVenta", entity.FechaVenta);
                param.Add("@ClienteNo", entity.ClienteNo);
                param.Add("@Observaciones", entity.Observaciones);
                param.Add("@EstadoVenta", entity.EstadoVenta);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
              
                param.Add("@VentaNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var ventaNo = await this._unit.VentasRepository.ExecRecordScopeAsync(
                    command: Ventas.ToInsert,
                    param: param,
                    scope: "@VentaNo",
                    commandType: CommandType.Text);

                if (ventaNo > 0)
                {
                    result.Success = true;
                    result.Data = ventaNo;
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
