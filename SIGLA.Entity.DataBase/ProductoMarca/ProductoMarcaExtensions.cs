using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoMarca
{
    public partial class ProductoMarca
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PRODUCTO_MARCA] (
            Descripcion,
           
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @Descripcion,
         
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProductoMarcaNo = SCOPE_IDENTITY();
        SELECT @ProductoMarcaNo;";
            }
            private set { }
        }


        public static string ToSearchByDescripcion
        {
            get
            {
                return @"
                SELECT TOP 1 *
                FROM PRODUCTO_MARCA
                WHERE Descripcion = @Descripcion AND Anulado = 0";
            }
            private set { }
        }


        public static string Tosp_spProductoMarcaList
        {
            get
            {
                return @"[spProductoMarcaList]";
                //return @"spProgramacionList4";
            }
            private set { }
        }








    }
}
