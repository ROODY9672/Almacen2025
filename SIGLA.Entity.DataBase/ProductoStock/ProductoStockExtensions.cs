using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoStock
{
    public partial class ProductoStock
    {
        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PRODUCTO_STOCK] (
            ProductoNo,
            AlmacenNo,
            Stock,
            UsuarioCreacion,
            FechaHoraCreacion 
        VALUES (
            @ProductoNo,
            @AlmacenNo,
            @Stock,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProductoStockNo = SCOPE_IDENTITY();
        SELECT @ProductoStockNo;";
            }
            private set { }
        }







    }
}
