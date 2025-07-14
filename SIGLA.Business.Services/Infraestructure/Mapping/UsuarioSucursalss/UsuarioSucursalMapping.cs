using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Business.Dto.UsuarioSucursalsss;
using SIGLA.Entity.DataBase.UsuariosFile;
using SIGLA.Entity.DataBase.UsuarioSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.UsuarioSucursalss
{
    public class UsuarioSucursalMapping : IUsuarioSucursalMapping
    {

        public UsuarioSucursal ToEntity(UsuarioSucursalCreacionDto dto)
        {
            if (dto == null)
            {
                return new UsuarioSucursal();
            }

            return new UsuarioSucursal
            {
                UsuarioSucursalNo = dto.UsuarioSucursalNo,
                UsuarioNo = dto.UsuarioNo,
                SucursalNo = dto.SucursalNo,
                EsPrincipal = dto.EsPrincipal,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }


        public IEnumerable<UsuarioSucursalColeccionDto> ToEnumerable(IEnumerable<UsuarioSucursal> entidad)
        {
            return entidad.Select(dto => new UsuarioSucursalColeccionDto()
            {
                UsuarioSucursalNo = dto.UsuarioSucursalNo,
                UsuarioNo = dto.UsuarioNo,
                SucursalNo = dto.SucursalNo,
                EsPrincipal = dto.EsPrincipal,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                SUCURSALES_NombreSucursal = dto.SUCURSALES_NombreSucursal,
                SUCURSALES_Direccion = dto.SUCURSALES_Direccion,
                SUCURSALES_Telefono = dto.SUCURSALES_Telefono,
                SUCURSALES_Correo = dto.SUCURSALES_Correo,
                SUCURSALES_Sede = dto.SUCURSALES_Sede == true ? "Principal" : "Sucursal",
                EMPRESA_RazonSocial = dto.EMPRESA_RazonSocial,
                EMPRESA_NombreComercial = dto.EMPRESA_NombreComercial,
                EMPRESA_NumRuc = dto.EMPRESA_NumRuc,
                EMPRESA_Direccion = dto.EMPRESA_Direccion,
                EMPRESA_Telefono1 = dto.EMPRESA_Telefono1,
                EMPRESA_Telefono2 = dto.EMPRESA_Telefono2,
                EMPRESA_Correo = dto.EMPRESA_Correo
            });
        }















    }
}
