using SIGLA.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGLA.Business.Services.Wrapper
{
    public class BaseServices
    {
        protected readonly IUnitOfWork _unit;

        public BaseServices(IUnitOfWork unit)
        {
            this._unit = unit;
        }
    }
}
