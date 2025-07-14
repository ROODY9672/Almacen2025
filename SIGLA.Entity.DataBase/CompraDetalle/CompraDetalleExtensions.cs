using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.CompraDetalle
{
    public partial class CompraDetalle
    {


        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[COMPRAS_DETALLE] (
            CompraNo,
            ProductoNo,
            Cantidad,
            PrecioUnitario,
            Subtotal,
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @CompraNo,
            @ProductoNo,
            @Cantidad,
            @PrecioUnitario,
            @Subtotal,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @CompraDetalleNo = SCOPE_IDENTITY();
        SELECT @CompraDetalleNo;";
            }
            private set { }
        }







    }
}
