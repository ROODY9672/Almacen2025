using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.SucursalesFile
{
    public partial class SucursalesFile
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[SUCURSALES_FILE] (
            FlagTipoFoto,
            NombreDocumento,
            NombreArchivo,
            ContentType,
            Data,
          
            FechaHoraCreacion,
            UsuarioCreacion,
            SucursalNo 
        )
        VALUES (
            @FlagTipoFoto,
            @NombreDocumento,
            @NombreArchivo,
            @ContentType,
            @Data,
           
            GETDATE(),
            @UsuarioCreacion,
            @SucursalNo
        );

        SET @SucursalesFileNo = SCOPE_IDENTITY();
        SELECT @SucursalesFileNo;";
            }
            private set { }
        }




        public static string ToSelectedTipoFotoTodos
        {
            get
            {
                return @"
                    SELECT * FROM SUCURSALES_FILE F
                        WHERE F.SucursalNo = @SucursalNo
                         AND F.Anulado = 0;";
                
            }
            private set { }
        }






    }
}
