using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.MarcaSucursal
{
    public partial class MarcaSucursal
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[MarcaSucursal] (
            ProductoMarcaNo,
            SucursalNo 
        
        ) 
        VALUES (
            @ProductoMarcaNo,
            @SucursalNo 
          
        );

        SET @MarcaSucursalId = SCOPE_IDENTITY();
        SELECT @MarcaSucursalId;";
            }
            private set { }
        }

        public static string ToExistMarcaSucursal
        {
            get
            {
                return @"
                SELECT 1 
                FROM MarcaSucursal 
                WHERE ProductoMarcaNo = @ProductoMarcaNo 
                  AND SucursalNo = @SucursalNo";
            }
            private set { }
        }



    }
}
