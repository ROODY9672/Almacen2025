using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Entity.DataBase.Empresa;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Sucursalesss
{
    public class SucursalesMapping : ISucursalesMapping
    {


        public Sucursales ToEntity(SucursalesCreacionDto dto)
        {
            if (dto == null)
            {
                return new Sucursales();
            }

            return new Sucursales
            {
                SucursalNo = dto.SucursalNo,
                NombreSucursal = dto.NombreSucursal,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                EmpresaNo = dto.EmpresaNo,
                Sede = dto.Sede,
                
            };
        }




        public IEnumerable<SucursalesColeccionDto> ToEnumerable(IEnumerable<Sucursales> entidad)
        {
            return entidad.Select(dto => new SucursalesColeccionDto()
            {

                SucursalNo = dto.SucursalNo,
                NombreSucursal = dto.NombreSucursal,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = dto.UsuarioCreacion,
                //FechaHoraCreacion = dto.FechaHoraCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion.HasValue ? dto.FechaHoraCreacion.Value.ToString("dd/MM/yyyy HH:mm") : string.Empty,
              
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,

                EMPRESA_RazonSocial = dto.EMPRESA_RazonSocial,
                EMPRESA_NumRuc = dto.EMPRESA_NumRuc,
                EMPRESA_Direccion = dto.EMPRESA_Direccion,
                EMPRESA_Telefono1 = dto.EMPRESA_Telefono1,
                Sede = dto.Sede == true ? "Principal" : "Sucursal",
            });
        }





        public SucursalesObjetoDto toDto(Sucursales dto)
        {
            return new SucursalesObjetoDto()
            {
                SucursalNo = dto.SucursalNo,
                NombreSucursal = dto.NombreSucursal,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                EmpresaNo = dto.EmpresaNo,
                EMPRESA_RazonSocial = dto.EMPRESA_RazonSocial,
                EMPRESA_NumRuc = dto.EMPRESA_NumRuc,
                EMPRESA_Direccion = dto.EMPRESA_Direccion,
                EMPRESA_Telefono1 = dto.EMPRESA_Telefono1,
            };
        }




        public Sucursales ToEntityUpdate(SucursalesObjetoDto dto)
        {
            if (dto == null)
            {
                return new Sucursales();
            }

            return new Sucursales
            {
                SucursalNo = dto.SucursalNo,
                NombreSucursal = dto.NombreSucursal,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                EmpresaNo = dto.EmpresaNo,
            };
        }







    }
}
