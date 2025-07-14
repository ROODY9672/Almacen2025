using SIGLA.Business.Dto.Usuariossss;
using SIGLA.Entity.DataBase.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Usuariosss
{
    public class UsuariosMapping : IUsuariosMapping
    {
        public Usuarios ToEntity(UsuariosCreacionDto dto)
        {
            if (dto == null)
            {
                return new Usuarios();
            }

            return new Usuarios
            {
                UsuarioNo = dto.UsuarioNo,
                NombreUsuario = dto.NombreUsuario,
                Correo = dto.Correo,
                ClaveHash = dto.ClaveHash,
                SucursalNo = dto.SucursalNo,
                Rol = dto.Rol,

                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion == default ? DateTime.Now : dto.FechaHoraCreacion,

                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,

                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                NumeroDocumento = dto.NumeroDocumento,
                Sexo = dto.Sexo,
            };
        }


        public IEnumerable<UsuariosColeccionDto> ToEnumerable(IEnumerable<Usuarios> entidad)
        {
            return entidad.Select(dto => new UsuariosColeccionDto
            {
                UsuarioSucursalNo = dto.UsuarioSucursalNo,
                UsuarioNo = dto.UsuarioNo,
                SucursalNo = dto.SucursalNo,
                EsPrincipal = dto.EsPrincipal,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion?.ToString("dd/MM/yyyy HH:mm") ?? string.Empty,
       
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,

             
            

                SUCURSALES_NombreSucursal = dto.SUCURSALES_NombreSucursal,
                SUCURSALES_Direccion = dto.SUCURSALES_Direccion,
                SUCURSALES_Telefono = dto.SUCURSALES_Telefono,
                SUCURSALES_Sede = dto.SUCURSALES_Sede == true ? "Principal" : "Sucursal",


                USUARIOS_NombreUsuario = dto.NombreUsuario,
                USUARIOS_ApellidoPaterno = dto.ApellidoPaterno,
                USUARIOS_ApellidoMaterno = dto.ApellidoMaterno,
                USUARIOS_NumeroDocumento = dto.NumeroDocumento,
                USUARIOS_Sexo = dto.Sexo,
                USUARIOS_Rol = dto.Rol,
                USUARIOS_Correo = dto.Correo,
            });
        }






        public UsuarioObjetoDto toDto(Usuarios dto)
        {
            return new UsuarioObjetoDto()
            {
                UsuarioNo = dto.UsuarioNo,
                NombreUsuario = dto.NombreUsuario,
                Correo = dto.Correo,
                ClaveHash = dto.ClaveHash,
                Rol = dto.Rol,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                NumeroDocumento = dto.NumeroDocumento,
                Sexo = dto.Sexo
            };
        }


        public Usuarios ToEntityUpdate(UsuarioObjetoDto dto)
        {
            if (dto == null)
            {
                return new Usuarios();
            }

            return new Usuarios
            {
                UsuarioNo = dto.UsuarioNo,
                NombreUsuario = dto.NombreUsuario,
                Correo = dto.Correo,
                ClaveHash = dto.ClaveHash,
                //SucursalNo = dto.SucursalNo,
                Rol = dto.Rol,

                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion == default ? DateTime.Now : dto.FechaHoraCreacion,

                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,

                ApellidoPaterno = dto.ApellidoPaterno,
                ApellidoMaterno = dto.ApellidoMaterno,
                NumeroDocumento = dto.NumeroDocumento,
                Sexo = dto.Sexo,
            };
        }




    }
}
