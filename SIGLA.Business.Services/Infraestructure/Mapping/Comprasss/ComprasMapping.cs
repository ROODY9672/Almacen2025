using SIGLA.Business.Dto.Comprassss;
using SIGLA.Entity.DataBase.Compras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Infraestructure.Mapping.Comprasss
{
    public class ComprasMapping  :IComprasMapping
    {


        public Compras ToEntity(ComprasCreacionDto dto)
        {
            if (dto == null)
            {
                return new Compras();
            }

            return new Compras
            {
                CompraNo = dto.CompraNo,
                NumeroCompra = dto.NumeroCompra,
                FechaCompra = dto.FechaCompra,
                ProveedorNo = dto.ProveedorNo,
                Observaciones = dto.Observaciones,
                EstadoCompra = dto.EstadoCompra,
                UsuarioCreacion = string.IsNullOrEmpty(dto.UsuarioCreacion) ? "SYSADMIN" : dto.UsuarioCreacion,
                FechaHoraCreacion = dto.FechaHoraCreacion,
                UsuarioBaja = dto.UsuarioBaja,
                FechaHoraBaja = dto.FechaHoraBaja,
                Anulado = dto.Anulado
            };
        }

    }
}
