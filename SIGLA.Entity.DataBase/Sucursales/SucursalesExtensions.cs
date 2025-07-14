using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Sucursales
{
    public partial class Sucursales
    {

        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[SUCURSALES] (
            NombreSucursal,
            Direccion,
            Telefono,
            Correo, 
            EmpresaNo,
            Sede,
            UsuarioCreacion,
            FechaHoraCreacion 
        )
        VALUES (
            @NombreSucursal,
            @Direccion,
            @Telefono,
            @Correo,
            @EmpresaNo,
            @Sede,
            @UsuarioCreacion,
            GETDATE() 
        );

        SET @SucursalNo = SCOPE_IDENTITY();
        SELECT @SucursalNo;";
            }
            private set { }
        }




        public static string Tosp_spSucursalesList
        {
            get
            {
                return @"[spSucursalesList]";
                //return @"spProgramacionList4";
            }
            private set { }
        }




        public static string To_Selected
        {
            get
            {
                return @"SELECT * FROM [dbo].[SUCURSALES] WHERE Anulado = 0";
                // return @"spProgramacionList4";
            }
            private set { }
        }



        public static string ToObtenerSucursal
        {
            get
            {
                return @"SELECT 
                            S.*,
                            E.RazonSocial AS EMPRESA_RazonSocial,
                            E.NombreComercial AS EMPRESA_NombreComercial,
                            E.NumRuc AS EMPRESA_NumRuc
                        FROM 
                            SUCURSALES S
                        LEFT JOIN 
                            EMPRESA E ON S.EmpresaNo = E.EmpresaNo
                        WHERE  
                            S.SucursalNo = @SucursalNo
                            AND S.Anulado = 0;";
            }
            private set { }
        }



        public static string ToUpdate
        {
            get
            {
                return @"
        UPDATE SUCURSALES
        SET
            NombreSucursal = @NombreSucursal,
            Direccion = @Direccion,
            Telefono = @Telefono,
            Correo = @Correo 
        WHERE
            SucursalNo = @SucursalNo
            AND Anulado = 0;";
            }
            private set { }
        }






    }
}
