using SIGLA.Business.Dto.Sucursalessss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.Sucursales;
using SIGLA.Entity.DataBase.UsuariosFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.UsuariosFiless
{
    public class UsuariosFileMapping : IUsuariosFileMapping
    {


        public UsuariosFile ToEntity(UsuariosFileCreacionDto dto)
        {
            if (dto == null)
            {
                return new UsuariosFile();
            }

            return new UsuariosFile
            {
                FlagTipoFoto = dto.FlagTipoFoto,
                NombreDocumento = dto.NombreDocumento,
                NombreArchivo = dto.NombreArchivo,
                ContentType = dto.ContentType,
                Data = dto.Data,
                Anulado = dto.Anulado,
                FechaHoraAnulado = dto.FechaHoraAnulado,
                UsuarioAnulado = dto.UsuarioAnulado,
                FechaHoraCreacion = dto.FechaHoraCreacion  ,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                UsuarioNo = dto.UsuarioNo
            };
        }

        public IEnumerable<UsuariosFileColeccionDto> ToEnumerable(IEnumerable<UsuariosFile> entidad)
        {
            return entidad.Select(dto => new UsuariosFileColeccionDto()
            {
                UsuariosFileNo = dto.UsuariosFileNo,
                FlagTipoFoto = dto.FlagTipoFoto,
                NombreDocumento = dto.NombreDocumento,
                NombreArchivo = dto.NombreArchivo,
                ContentType = dto.ContentType,
                Data = dto.Data,
                Anulado = dto.Anulado,
                FechaHoraAnulado = dto.FechaHoraAnulado,
                UsuarioAnulado = dto.UsuarioAnulado,
                FechaHoraCreacion = dto.FechaHoraCreacion.HasValue
                    ? dto.FechaHoraCreacion.Value.ToString("dd/MM/yyyy HH:mm")
                    : string.Empty,
                UsuarioCreacion = dto.UsuarioCreacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                UsuarioNo = dto.UsuarioNo
            });
        }



        public UsuariosFileColeccionDto ToDto(UsuariosFile dto)
        {
            return new UsuariosFileColeccionDto
            {
                FlagTipoFoto = dto.FlagTipoFoto,
                NombreDocumento = dto.NombreDocumento,
                NombreArchivo = dto.NombreArchivo,
                ContentType = dto.ContentType,
                Data = dto.Data,
                Anulado = dto.Anulado,
                FechaHoraAnulado = dto.FechaHoraAnulado,
                UsuarioAnulado = dto.UsuarioAnulado,
                //FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                UsuarioNo = dto.UsuarioNo
            };
        }



    }
}
