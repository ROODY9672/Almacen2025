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
    public class EmpresaMapping : IEmpresaMapping
    {


        public EmpresaObjetoDto toDto(Empresa dto)
        {
            return new EmpresaObjetoDto()
            {
                EmpresaNo = dto.EmpresaNo,
                RazonSocial = dto.RazonSocial,
                NombreComercial = dto.NombreComercial,
                NumRuc = dto.NumRuc,
                Direccion = dto.Direccion,
                Telefono1 = dto.Telefono1,
                Telefono2 = dto.Telefono2,
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
