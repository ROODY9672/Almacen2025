using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoCategoria
{
    public partial class ProductoCategoria
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PRODUCTO_CATEGORIA] (
            Descripcion,
           
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @Descripcion,
         
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProductoCategoriaNo = SCOPE_IDENTITY();
        SELECT @ProductoCategoriaNo;";
            }
            private set { }
        }


    }
}
