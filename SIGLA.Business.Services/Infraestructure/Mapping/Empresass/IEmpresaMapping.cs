using SIGLA.Business.Dto.Empresasss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Empresass
{
    public interface   IEmpresaMapping
    {
        EmpresaObjetoDto toDto(Empresa dto);

    }
}
