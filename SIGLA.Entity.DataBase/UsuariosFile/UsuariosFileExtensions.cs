using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.UsuariosFile
{
    public partial class UsuariosFile
    {



        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[USUARIOS_FILE] (
            FlagTipoFoto,
            NombreDocumento,
            NombreArchivo,
            ContentType,
            Data,
          
            FechaHoraCreacion,
            UsuarioCreacion,
            UsuarioNo 
        )
        VALUES (
            @FlagTipoFoto,
            @NombreDocumento,
            @NombreArchivo,
            @ContentType,
            @Data,
           
            GETDATE(),
            @UsuarioCreacion,
            @UsuarioNo
        );

        SET @UsuariosFileNo = SCOPE_IDENTITY();
        SELECT @UsuariosFileNo;";
            }
            private set { }
        }






        public static string ToSelectedTipoFotoTodos
        {
            get
            {
                return @"
                    SELECT * FROM USUARIOS_FILE F
                        WHERE F.UsuarioNo = @UsuarioNo
                         AND F.Anulado = 0;";
                // TipoFotoNo=@TipoFotoNo




            }
            private set { }
        }









    }
}
