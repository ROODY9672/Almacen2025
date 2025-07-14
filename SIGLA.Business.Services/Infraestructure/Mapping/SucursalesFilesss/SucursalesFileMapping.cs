using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.SucursalesFile;
using SIGLA.Entity.DataBase.UsuariosFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.SucursalesFilesss
{
    public class SucursalesFileMapping : ISucursalesFileMapping
    {
        public SucursalesFile ToEntity(SucursalesFileCreacionDto dto)
        {
            if (dto == null)
            {
                return new SucursalesFile();
            }

            return new SucursalesFile
            {
                SucursalFileNo = dto.SucursalFileNo,
                FlagTipoFoto = dto.FlagTipoFoto,
                NombreDocumento = dto.NombreDocumento,
                NombreArchivo = dto.NombreArchivo,
                ContentType = dto.ContentType,
                Data = dto.Data,
                Anulado = dto.Anulado,
                FechaHoraAnulado = dto.FechaHoraAnulado,
                UsuarioAnulado = dto.UsuarioAnulado,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraModificacion = dto.FechaHoraModificacion,
                UsuarioModificacion = dto.UsuarioModificacion,
                SucursalNo = dto.SucursalNo
            };
        }

        public IEnumerable<SucursalesFileColeccionDto> ToEnumerable(IEnumerable<SucursalesFile> entidad)
        {
            return entidad.Select(dto => new SucursalesFileColeccionDto()
            {
                SucursalFileNo = dto.SucursalFileNo,
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
                SucursalNo = dto.SucursalNo
            });
        }



    }
}
