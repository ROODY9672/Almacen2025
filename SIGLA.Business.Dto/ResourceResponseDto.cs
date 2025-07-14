using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Dto
{
    public class ResourceDto
    {
        public bool Success { get; set; } = false;
        public string ErrorMessage { get; set; } = string.Empty;
    }

    public class ResourceResponseDto<T> : ResourceDto
    {
        public T Data { get; set; }
    }
}
