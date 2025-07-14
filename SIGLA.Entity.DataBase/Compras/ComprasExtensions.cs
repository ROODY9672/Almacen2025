using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Compras
{
    public partial class Compras
    {
        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[COMPRAS] (
            NumeroCompra,
            FechaCompra,
            ProveedorNo,
            Observaciones,
            EstadoCompra,
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @NumeroCompra,
            @FechaCompra,
            @ProveedorNo,
            @Observaciones,
            @EstadoCompra,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @CompraNo = SCOPE_IDENTITY();
        SELECT @CompraNo;";
            }
            private set { }
        }


    }
}
