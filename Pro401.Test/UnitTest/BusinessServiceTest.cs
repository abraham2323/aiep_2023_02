using Pro401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro401.Test.UnitTest
{
    [TestClass]
    public class BusinessServiceTest
    {
        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnFalse()
        {

            //Preparacion

            var service = new BusinessService();
            var color = "negro";

            //Ejecucion

            var resultado = service.PrimeraLetraMayuscula(color);

            //Verificacion

            Assert.IsFalse(resultado);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnTrue()
        {
            //Preparacion

            var service = new BusinessService();
            var color = "Negro";

            //Ejecucion

            var resultado = service.PrimeraLetraMayuscula(color);

            //Verificacion

            Assert.IsTrue(resultado);
        }
    }
}
