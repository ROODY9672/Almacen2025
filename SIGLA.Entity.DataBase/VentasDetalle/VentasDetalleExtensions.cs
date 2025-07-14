using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.VentasDetalle
{
    public partial class VentasDetalle
    {


        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[VENTAS_DETALLE] (
            VentaNo,
            ProductoNo,
            Cantidad,
            PrecioUnitario,
            Subtotal,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @VentaNo,
            @ProductoNo,
            @Cantidad,
            @PrecioUnitario,
            @Subtotal,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @VentaDetalleId = SCOPE_IDENTITY();
        SELECT @VentaDetalleId;";
            }
            private set { }
        }




    }
}
