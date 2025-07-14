using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Ventas
{
    public partial class Ventas
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[VENTAS] (
            NumeroVenta,
            FechaVenta,
            ClienteNo,
            Observaciones,
            EstadoVenta,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @NumeroVenta,
            @FechaVenta,
            @ClienteNo,
            @Observaciones,
            @EstadoVenta,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @VentaNo = SCOPE_IDENTITY();
        SELECT @VentaNo;";
            }
            private set { }
        }





    }
}
