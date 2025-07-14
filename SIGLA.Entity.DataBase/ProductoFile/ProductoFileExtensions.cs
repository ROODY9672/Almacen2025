using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.ProductoFile
{
    public partial class ProductoFile
    {

        
            public static string ToInsert
            {
                get
                {
                    return @"
                INSERT INTO [dbo].[PRODUCTO_FILE] (
                    FlagTipoFoto,
                    NombreDocumento,
                    NombreArchivo,
                    ContentType,
                    Data,
                    FechaHoraCreacion,
                    UsuarioCreacion,
                    ProductoNo
                )
                VALUES (
                    @FlagTipoFoto,
                    @NombreDocumento,
                    @NombreArchivo,
                    @ContentType,
                    @Data,
                    GETDATE(),
                    @UsuarioCreacion,
                    @ProductoNo
                );

                SET @ProductoFileNo = SCOPE_IDENTITY();
                SELECT @ProductoFileNo;";
                }
                private set { }
            }
      





    }
}
