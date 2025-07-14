using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoUnidadMedida
{
    public partial class ProductoUnidadMedida
    {
        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PRODUCTO_UNIDAD_MEDIDA] (
            Descripcion,    
            Codigo,

           
            UsuarioCreacion,
            FechaHoraCreacion 
        ) 
        VALUES (
            @Descripcion,
            @Codigo,
         
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProductoUnidadMedidaNo = SCOPE_IDENTITY();
        SELECT @ProductoUnidadMedidaNo;";
            }
            private set { }
        }



    }
}
