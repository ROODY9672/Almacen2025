using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Producto
{
    public partial class Producto
    {



        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PRODUCTOS] (
            CodigoProducto,
            NombreProducto,
            Descripcion,
            UnidadMedida,
            PrecioCosto,
            PrecioVenta,
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @CodigoProducto,
            @NombreProducto,
            @Descripcion,
            @UnidadMedida,
            @PrecioCosto,
            @PrecioVenta,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProductoNo = SCOPE_IDENTITY();
        SELECT @ProductoNo;";
            }
            private set { }
        }





    }
}
