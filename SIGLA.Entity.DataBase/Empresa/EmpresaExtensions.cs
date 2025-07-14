using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Entity.DataBase.Empresa
{
    public partial class Empresa
    {

        public static string ToSelect
        {
            get
            {
                return @"SELECT * 
                        FROM [dbo].[EMPRESA] 
                        WHERE Anulado = 0;";
            }
            private set { }
        }



    }
}
