using SIGLA.Business.Dto.Comprassss;
using SIGLA.Business.Dto.MarcaSucursalsss;
using SIGLA.Entity.DataBase.Compras;
using SIGLA.Entity.DataBase.MarcaSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.MarcaSucursalss
{
    public class MarcaSucursalMapping : IMarcaSucursalMapping
    {


        public MarcaSucursal ToEntity(MarcaSucursalCreacionDto dto)
        {
            if (dto == null)
            {
                return new MarcaSucursal();
            }

            return new MarcaSucursal
            {
                MarcaSucursalId = dto.MarcaSucursalId,
                ProductoMarcaNo = dto.ProductoMarcaNo,
                SucursalNo = dto.SucursalNo,
             
                //UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                //FechaHoraCreacion = dto.FechaHoraCreacion,
                //UsuarioBaja = dto.UsuarioBaja,
                //FechaHoraBaja = dto.FechaHoraBaja,
                //Anulado = dto.Anulado
            };
        }







    }
}
