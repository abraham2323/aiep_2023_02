using Pro401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro401.Test.Moq
{
    public class BusinessServiceMoq_PrimeraLetraMayuscula_True : IBusinessService
    {
        public bool PrimeraLetraMayuscula(string color)
        {
            return true;
        }
    }
}
