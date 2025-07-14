using SIGLA.Business.Dto.Proveedoressss;
using SIGLA.Entity.DataBase.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Proveedoresss
{
    public class ProveedoresMapping : IProveedoresMapping
    {

        public Proveedores ToEntity(ProveedoresCreacionDto dto)
        {
            if (dto == null)
            {
                return new Proveedores();
            }

            return new Proveedores
            {
                ProveedorNo = dto.ProveedorNo,
                RazonSocial = dto.RazonSocial,
                RUC = dto.RUC,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }




    }
}
