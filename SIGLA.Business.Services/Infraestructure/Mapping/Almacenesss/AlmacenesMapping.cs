using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Entity.DataBase.Almacenes;
using SIGLA.Entity.DataBase.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Almacenesss
{
    public class AlmacenesMapping : IAlmacenesMapping
    {


        public Almacenes ToEntity(AlmacenesCreacionDto dto)
        {
            if (dto == null)
            {
                return new Almacenes();
            }

            return new Almacenes
            {
                AlmacenNo = dto.AlmacenNo,
                NombreAlmacen = dto.NombreAlmacen,
                Direccion = dto.Direccion,
                SucursalNo = dto.SucursalNo,
                UsuarioNo = dto.UsuarioNo,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ,
            };
        }



        public IEnumerable<AlmacenesColeccionDto> ToEnumerable(IEnumerable<Almacenes> entidad)
        {
            return entidad.Select(dto => new AlmacenesColeccionDto()
            {
                AlmacenNo = dto.AlmacenNo,
                NombreAlmacen = dto.NombreAlmacen,
                Direccion = dto.Direccion,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion.HasValue
                    ? dto.FechaHoraCreacion.Value.ToString("dd/MM/yyyy HH:mm")
                    : string.Empty,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado,
                SucursalNo = dto.SucursalNo,
                UsuarioNo = dto.UsuarioNo
            });
        }











    }
}
