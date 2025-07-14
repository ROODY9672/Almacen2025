using SIGLA.Business.Dto.CompraDetallesss;
using SIGLA.Entity.DataBase.CompraDetalle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.CompraDetalless
{
    public class CompraDetalleMapping : ICompraDetalleMapping
    {


        public CompraDetalle ToEntity(CompraDetalleCreacionDto dto)
        {
            if (dto == null)
            {
                return new CompraDetalle();
            }

            return new CompraDetalle
            {
                CompraDetalleNo = dto.CompraDetalleNo,
                CompraNo = dto.CompraNo,
                ProductoNo = dto.ProductoNo,
                Cantidad = dto.Cantidad,
                PrecioUnitario = dto.PrecioUnitario,
                Subtotal = dto.Subtotal,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion ,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }



    }
}
