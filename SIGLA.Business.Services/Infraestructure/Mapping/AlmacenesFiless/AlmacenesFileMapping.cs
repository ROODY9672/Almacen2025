using SIGLA.Business.Dto.AlmacenesFilesss;
using SIGLA.Business.Dto.SucursalesFilesss;
using SIGLA.Entity.DataBase.AlmacenesFile;
using SIGLA.Entity.DataBase.SucursalesFile;
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

       
    }
}
