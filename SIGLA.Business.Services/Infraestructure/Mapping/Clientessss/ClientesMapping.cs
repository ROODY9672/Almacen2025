using SIGLA.Business.Dto.Clientessss;
using SIGLA.Entity.DataBase.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Clientessss
{
    public class ClientesMapping : IClientesMapping
    {




        public Clientes ToEntity(ClientesCreacionDto dto)
        {
            if (dto == null)
            {
                return new Clientes();
            }

            return new Clientes
            {
                ClienteNo = dto.ClienteNo,
                NombreCliente = dto.NombreCliente,
                DocumentoIdentidad = dto.DocumentoIdentidad,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ,
            };
        }

    }
}
