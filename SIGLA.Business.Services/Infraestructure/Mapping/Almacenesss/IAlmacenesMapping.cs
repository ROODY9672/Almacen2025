using SIGLA.Business.Dto.Almacenessss;
using SIGLA.Entity.DataBase.Almacenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Almacenesss
{
    public interface IAlmacenesMapping
    {
        Almacenes ToEntity(AlmacenesCreacionDto dto);
        IEnumerable<AlmacenesColeccionDto> ToEnumerable(IEnumerable<Almacenes> entidad);
    }
}
