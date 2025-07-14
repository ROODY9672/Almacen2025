using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Usuarios
{
    public partial class Usuarios
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[USUARIOS] (
            NombreUsuario,
            Correo,
            ClaveHash,
          
            Rol,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @NombreUsuario,
            @Correo,
            @ClaveHash,
   
            @Rol,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @UsuarioNo = SCOPE_IDENTITY();
        SELECT @UsuarioNo;";
            }
            private set { }
        }


        public static string Tosp_sp_ValidarUsuarioLogin
        {
            get
            {
                return @"sp_ValidarUsuarioLogin";
                //return @"spProgramacionList4";
            }
            private set { }
        }
     
        public static string ToInsertUsuarioCompleto
        {
            get
            {
                return @"
        INSERT INTO [dbo].[USUARIOS] (
            NombreUsuario,
            Correo,
            ApellidoPaterno,
            ApellidoMaterno,
            NumeroDocumento, 
            Sexo,
            ClaveHash,
            Rol,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @NombreUsuario,
            @Correo,
             @ApellidoPaterno,
            @ApellidoMaterno,
            @NumeroDocumento, 
            @Sexo,
            @ClaveHash,
            @Rol,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @UsuarioNo = SCOPE_IDENTITY();
        SELECT @UsuarioNo;";
            }
            private set { }
        }







        public static string Tosp_sp_ObtenerUsuariosConSucursales
        {
            get
            {

                return @"[sp_ObtenerUsuariosConSucursales]";
            }
            private set { }
        }



        public static string Tosp_sp_ObtenerUsuariosListado
        {
            get
            {

                return @"[sp_ObtenerUsuariosListado]";
            }
            private set { }
        }

        public static string Tosp_sp_ObtenerUsuariosConSucursalesXUsuarioNo
        {
            get
            {

                return @"[sp_ObtenerUsuariosConSucursalesXUsuarioNo]";
            }
            private set { }
        }

        public static string ToObtenerUsuario
        {
            get
            {
                return @"SELECT *
                        FROM USUARIOS
                        WHERE  UsuarioNo = @UsuarioNo
                        AND  Anulado = 0;";
                // TipoFotoNo=@TipoFotoNo




            }
            private set { }
        }



        public static string ToUpdate
        {
            get
            {
                return @"
            UPDATE USUARIOS
            SET
                NombreUsuario = @NombreUsuario,
                ApellidoPaterno = @ApellidoPaterno,
                ApellidoMaterno = @ApellidoMaterno,
                NumeroDocumento = @NumeroDocumento,
                Sexo = @Sexo,
                Rol = @Rol 
            WHERE
                UsuarioNo = @UsuarioNo
                AND Anulado = 0;";
            }
            private set { }
        }



        public static string ToVerificarCorreoExiste
        {
            get
            {
                return @"SELECT TOP 1 * FROM USUARIOS WHERE Correo = @Correo AND Anulado = 0";
            }
        }

        public static string ToVerificarDocumentoExiste
        {
            get
            {
                return @"SELECT TOP 1 * FROM USUARIOS WHERE NumeroDocumento = @NumeroDocumento AND Anulado = 0";
            }
        }
        public static string ToEliminarUsuario
        {
            get
            {
                return @"
            UPDATE USUARIOS
            SET Anulado = 1
            WHERE UsuarioNo = @UsuarioNo AND Anulado = 0";
            }
        }





    }
}
