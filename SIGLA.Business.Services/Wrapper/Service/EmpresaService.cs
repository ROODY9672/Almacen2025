using Dapper;
using SIGLA.Business.Dto;
using SIGLA.Business.Dto.Empresasss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Business.Services.Infraestructure;
using SIGLA.Business.Services.Wrapper.IService;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.Usuarios;
using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper.Service
{

    public class EmpresaService : BaseServices, IEmpresaService

        {


            private readonly IMappingGeneric _mapping;

            public EmpresaService(IUnitOfWork unit, IMappingGeneric mapping)
              : base(unit)
            {
                this._mapping = mapping;
            }






        public async Task<ResourceResponseDto<EmpresaObjetoDto>> ObtenerEmpresaObjetoDto()
        {
            var result = new ResourceResponseDto<EmpresaObjetoDto>();
            var param = new DynamicParameters();

            try
            {
                var query = await this._unit.EmpresaRepository.PostRecordsAsync<Empresa>(
                    command: Empresa.ToSelect,
                    param: param,
                    commandType: CommandType.Text);

                var empresa = query?.FirstOrDefault();

                if (empresa != null)
                {
                    var empresaDto = this._mapping.EmpresaMapping.toDto(empresa); // ✅ Usa tu método de mapeo
                    result.Success = true;
                    result.Data = empresaDto;
                }
                else
                {
                    result.Success = false;
                    result.ErrorMessage = "No se encontró información de la empresa.";
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
