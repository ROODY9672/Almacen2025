using SIGLA.Business.Dto.Clientessss;
using SIGLA.Entity.DataBase.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Clientessss
{
    public interface IClientesMapping
    {
        Clientes ToEntity(ClientesCreacionDto dto);

    }
}
