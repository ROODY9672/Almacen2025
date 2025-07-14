using SIGLA.Business.Dto.VentasDetallesss;
using SIGLA.Entity.DataBase.VentasDetalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.VentasDetalless
{
   public class VentasDetalleMapping : IVentasDetalleMapping
    {

        public VentasDetalle ToEntity(VentasDetalleCreacionDto dto)
        {
            if (dto == null)
            {
                return new VentasDetalle();
            }

            return new VentasDetalle
            {
                VentaDetalleId = dto.VentaDetalleId,
                VentaNo = dto.VentaNo,
                ProductoNo = dto.ProductoNo,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                Subtotal = dto.Subtotal,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion  , // Asegura valor por defecto si es null
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }



    }
}
