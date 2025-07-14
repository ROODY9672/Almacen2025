using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto
{
    public class PrediccionModel
    {
        public int NumeroIngresado { get; set; }
        public List<int> HistorialNumeros { get; set; } = new List<int>();
        public List<int> PrediccionModa { get; set; }
        public List<int> PrediccionMedia { get; set; }
        public List<int> PrediccionMediana { get; set; }
    }
}
