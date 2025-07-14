using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Clientessss;
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

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class ClientesService : BaseServices, IClientesService

    {

        private readonly IMappingGeneric _mapping;

        public ClientesService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }



        public async Task<ResourceResponseDto<int>> RegisterAsync(ClientesCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ClientesMapping.ToEntity(parameter);

                param.Add("@NombreCliente", entity.NombreCliente);
                param.Add("@DocumentoIdentidad", entity.DocumentoIdentidad);
                param.Add("@Direccion", entity.Direccion);
                param.Add("@Telefono", entity.Telefono);
                param.Add("@Correo", entity.Correo);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
                param.Add("@ClienteNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                // Ejecuta la inserción y obtiene el ID generado
                var clienteNo = await this._unit.ClientesRepository.ExecRecordScopeAsync(
                    command: Clientes.ToInsert,
                    param: param,
                    scope: "@ClienteNo",
                    commandType: CommandType.Text);

                if (clienteNo > 0)
                {
                    result.Success = true;
                    result.Data = clienteNo;
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
