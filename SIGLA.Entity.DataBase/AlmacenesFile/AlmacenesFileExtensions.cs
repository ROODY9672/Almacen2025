﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.AlmacenesFile
{
    public partial class AlmacenesFile
    {
        public static string ToInsert
        {
            get
            {
                return @"
        INSERT INTO [dbo].[ALMACENES_FILE] (
            FlagTipoFoto,
            NombreDocumento,
            NombreArchivo,
            ContentType,
            Data,
          
            FechaHoraCreacion,
            UsuarioCreacion,
            AlmacenNo 
        )
        VALUES (
            @FlagTipoFoto,
            @NombreDocumento,
            @NombreArchivo,
            @ContentType,
            @Data,
           
            GETDATE(),
            @UsuarioCreacion,
            @AlmacenNo
        );

        SET @AlmacenesFileNo = SCOPE_IDENTITY();
        SELECT @AlmacenesFileNo;";
            }
            private set { }
        }

    }
}
