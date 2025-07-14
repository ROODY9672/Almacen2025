using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Clientes
{
    public partial class Clientes
    {
        public static string ToInsert
        {
            get
            {
                return @"
            INSERT INTO [dbo].[CLIENTES] (
                NombreCliente,
                DocumentoIdentidad,
                Direccion,
                Telefono,
                Correo,
                UsuarioCreacion,
                FechaHoraCreacion
            ) 
            VALUES (
                @NombreCliente,
                @DocumentoIdentidad,
                @Direccion,
                @Telefono,
                @Correo,
                @UsuarioCreacion,
                GETDATE()
            );

            SET @ClienteNo = SCOPE_IDENTITY();
            SELECT @ClienteNo;";
            }
            private set { }
        }

    }
}
