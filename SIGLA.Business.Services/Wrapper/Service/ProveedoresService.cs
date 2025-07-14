using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Proveedoressss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Proveedores;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{


    public class ProveedoresService : BaseServices, IProveedoresService

    {


        private readonly IMappingGeneric _mapping;

        public ProveedoresService(IUnitOfWork unit, IMappingGeneric mapping)
          : base(unit)
        {
            this._mapping = mapping;
        }


        public async Task<ResourceResponseDto<int>> RegisterAsync(ProveedoresCreacionDto parameter)
        {
            var param = new DynamicParameters();
            var result = new ResourceResponseDto<int>();

            try
            {
                var entity = this._mapping.ProveedoresMapping.ToEntity(parameter); // Corregido: ProveedorMapping

                // Agregamos todos los parámetros esperados en el SQL
                param.Add("@RazonSocial", entity.RazonSocial);
                param.Add("@RUC", entity.RUC);
                param.Add("@Direccion", entity.Direccion);
                param.Add("@Telefono", entity.Telefono);
                param.Add("@Correo", entity.Correo);
                param.Add("@UsuarioCreacion", entity.UsuarioCreacion);
              
                param.Add("@ProveedorNo", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var proveedorNo = await this._unit.ProveedoresRepository.ExecRecordScopeAsync(
                    command: Proveedores.ToInsert,
                    param: param,
                    scope: "@ProveedorNo",
                    commandType: CommandType.Text);

                if (proveedorNo > 0)
                {
                    result.Success = true;
                    result.Data = proveedorNo;
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
