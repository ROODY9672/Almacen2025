using SIGLA.Business.Dto.AlmacenesFilesss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Business.Dto.UsuariosFilessss;
using SIGLA.Entity.DataBase.AlmacenesFile;
using SIGLA.Entity.DataBase.SucursalesFile;
using SIGLA.Entity.DataBase.UsuariosFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.AlmacenesFiless
{
    public class AlmacenesFileMapping : IAlmacenesFileMapping
    {
        public AlmacenesFile ToEntity(AlmacenesFileCreacionDto dto)
        {
            if (dto == null)
            {
                return new AlmacenesFile();
            }

            return new AlmacenesFile
            {
                AlmacenesFileNo = dto.AlmacenesFileNo,
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
                AlmacenNo = dto.AlmacenNo
            };
        }





        public IEnumerable<AlmacenesFileColeccionDto> ToEnumerable(IEnumerable<AlmacenesFile> entidad)
        {
            return entidad.Select(dto => new AlmacenesFileColeccionDto()
            {
                AlmacenesFileNo = dto.AlmacenesFileNo,
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
                //UsuarioNo = dto.UsuarioNo
            });
        }












    }
}
