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
    public interface IAlmacenesFileMapping
    {
        AlmacenesFile ToEntity(AlmacenesFileCreacionDto dto);

    }
}
