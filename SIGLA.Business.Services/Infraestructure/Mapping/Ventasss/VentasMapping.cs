using SIGLA.Business.Dto.Ventassss;
using SIGLA.Entity.DataBase.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Ventasss
{
    public class VentasMapping : IVentasMapping
    {


        public Ventas ToEntity(VentasCreacionDto dto)
        {
            if (dto == null)
            {
                return new Ventas();
            }

            return new Ventas
            {
                VentaNo = dto.VentaNo,
                NumeroVenta = dto.NumeroVenta,
                FechaVenta = dto.FechaVenta,
                ClienteNo = dto.ClienteNo,
                Observaciones = dto.Observaciones,
                EstadoVenta = dto.EstadoVenta,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ?? DateTime.Now, // Si es null, usa DateTime.Now
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }


    }
}
