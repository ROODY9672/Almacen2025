using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Comprassss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Clientes;
using SIGLA.Entity.DataBase.Compras;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{
    public class ComprasService : BaseServices, IComprasService

    {


        private readonly IMappingGeneric _mapping;

        public ComprasService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(ComprasCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ComprasMapping.ToEntity(parameter);

                param.Add("@NumeroCompra", entity.NumeroCompra);
                param.Add("@FechaCompra", entity.FechaCompra);
                param.Add("@ProveedorNo", entity.ProveedorNo);
                param.Add("@Observaciones", entity.Observaciones);
                param.Add("@EstadoCompra", entity.EstadoCompra);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
              
                param.Add("@CompraNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Ejecuta la inserción y obtiene el ID generado
                var compraNo = await this._unit.ComprasRepository.ExecRecordScopeAsync(
                    command: Compras.ToInsert,
                    param: param,
                    scope: "@CompraNo",
                    commandType: CommandType.Text);

                if (compraNo > 0)
                {
                    result.Success = true;
                    result.Data = compraNo;
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
