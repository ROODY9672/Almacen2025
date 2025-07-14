using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.UsuarioSucursal
{
    public partial class UsuarioSucursal
    {


        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[USUARIO_SUCURSAL] (
            UsuarioNo,
            SucursalNo,
            EsPrincipal,
            UsuarioCreacion,
            FechaHoraCreacion
        )
        VALUES (
            @UsuarioNo,
            @SucursalNo,
            @EsPrincipal,
            @UsuarioCreacion,
            GETDATE()
        );

        SET @UsuarioSucursalNo = SCOPE_IDENTITY();
        SELECT @UsuarioSucursalNo;";
            }
            private set { }
        }



        public static string ToObtenerUsuarioSucursalXUsuarioNo
        {
            get
            {
                return @"SELECT *
                        FROM USUARIO_SUCURSAL
                        WHERE  UsuarioNo = @UsuarioNo
                        AND  Anulado = 0;";
            }
            private set { }
        }


        public static string ToEliminarSucursalesPorUsuario
        {
            get
            {
                return @"
          UPDATE USUARIO_SUCURSAL
                SET Anulado = 1
                WHERE UsuarioNo = @UsuarioNo
                AND Anulado = 0;
                ;";
            }
            private set { }
        }





        public static string ToEliminarUsuarioSucursal
        {
            get
            {
                return @"
            UPDATE USUARIO_SUCURSAL
            SET Anulado = 1
            WHERE UsuarioNo = @UsuarioNo AND Anulado = 0";
            }
        }





        public static string ToObtenerUsuarioSucursalXUsuarioNoDetalle
        {
            get
            {
                return @"SELECT 
                            US.*,    
                            S.NombreSucursal AS SUCURSALES_NombreSucursal,
                            S.Direccion AS SUCURSALES_Direccion,
                            S.Telefono AS SUCURSALES_Telefono,
                            S.Correo AS SUCURSALES_Correo,
                            S.Sede AS SUCURSALES_Sede,
                                E.RazonSocial AS EMPRESA_RazonSocial,
								E.NombreComercial AS EMPRESA_NombreComercial,
								E.NumRuc AS EMPRESA_NumRuc,
								E.Direccion AS EMPRESA_Direccion,
								E.Telefono1 AS EMPRESA_Telefono1,
								E.Telefono2 AS EMPRESA_Telefono2,
								E.Correo AS EMPRESA_Correo
                        FROM 
                            USUARIO_SUCURSAL US
                        LEFT JOIN 
                            SUCURSALES S ON US.SucursalNo = S.SucursalNo
                        LEFT JOIN 
				        	 EMPRESA  E ON E.EmpresaNo = S.EmpresaNo
                        WHERE 
                            US.UsuarioNo = @UsuarioNo
                            AND US.Anulado = 0;

                        ;";
            }
            private set { }
        }







    }
}
