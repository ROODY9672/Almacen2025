using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Almacenes
{
    public partial class Almacenes
    {


        public static string ToInsert
        {
            get
            {
                return @"
            INSERT INTO [dbo].[ALMACENES] (
                NombreAlmacen,
                Direccion,
                SucursalNo,
                UsuarioNo,
                UsuarioCreacion,
                FechaHoraCreacion
            ) 
            VALUES (
                @NombreAlmacen,
                @Direccion,
                @SucursalNo,
                @UsuarioNo,
                @UsuarioCreacion,
                GETDATE()
            );

            SET @AlmacenNo = SCOPE_IDENTITY();
            SELECT @AlmacenNo;";
            }
            private set { }
        }



        public static string Tosp_spAlmacenesList
        {
            get
            {
                return @"[spAlmacenesList]";
                //return @"spProgramacionList4";
            }
            private set { }
        }












    }
}
