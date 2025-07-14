using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Proveedores
{
    public partial class Proveedores
    {


        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[PROVEEDORES] (
            RazonSocial,
            RUC,
            Direccion,
            Telefono,
            Correo,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @RazonSocial,
            @RUC,
            @Direccion,
            @Telefono,
            @Correo,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @ProveedorNo = SCOPE_IDENTITY();
        SELECT @ProveedorNo;";
            }
            private set { }
        }








    }
}
