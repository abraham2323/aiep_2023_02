using Microsoft.EntityFrameworkCore;
using Moq;
using Pro401.Entities;
using Pro401.Services;
using Pro401.Test.Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro401.Test.UnitTest
{
    [TestClass]
    public class VehiculoServiceTest : BaseTest
    {
        [TestMethod]
        public async Task PatenteExiste_ReturnFalse()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1, businessMoq);
            var entity = new Vehiculo { Patente = "aaaa", Color = "Azul" };

            //Ejecucion
            var result = await service.PatenteExiste(entity.Patente);

            //Verificacion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public async Task PatenteExiste_ReturnTrue()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1 , businessMoq);
            var entity = new Vehiculo { Patente = "aaaa", Color = "Azul" };
            context1.Vehiculos.Add(new Vehiculo { Patente = "aaaa", Color = "Morado" });
            await context1.SaveChangesAsync();

            //Ejecucion
            var result = await service.PatenteExiste(entity.Patente);

            //Verificacion
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnFalse()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var busineesMoq = new BusinessServiceMoq_PrimeraLetraMayuscula_False();
            var service = new VehiculoService(context1, busineesMoq);
            var color = "celeste";

            //Ejecucion
            var result = service.PrimeraLetraMayuscula(color);

            //Verificacion
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnTrue()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var busineesMoq = new BusinessServiceMoq_PrimeraLetraMayuscula_True();
            var service = new VehiculoService(context1, busineesMoq);
            var color = "celeste";

            //Ejecucion
            var result = service.PrimeraLetraMayuscula(color);

            //Verificacion
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnFalse_moq()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var businessMoq = new Mock<IBusinessService>();
            businessMoq.Setup(x=>x.PrimeraLetraMayuscula(It.IsAny<string>())).Returns(false);
            var service = new VehiculoService(context1, businessMoq.Object);
            var color = "celeste";

            //Ejecucion
            var result = service.PrimeraLetraMayuscula(color);

            //Validacion
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PrimeraLetraMayuscula_ReturnTrue_moq()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var businessMoq = new Mock<IBusinessService>();
            businessMoq.Setup(x => x.PrimeraLetraMayuscula(It.IsAny<string>())).Returns(true);
            var service = new VehiculoService(context1, businessMoq.Object);
            var color = "celeste";

            //Ejecucion
            var result = service.PrimeraLetraMayuscula(color);

            //Validacion
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task Insert()
        {
            //Preparacion
            var dbName = Guid.NewGuid().ToString();
            var context1 = BuieldDataBaseContext(dbName);
            var vehiculoToInsert = new Vehiculo { Patente = "gggg16", 
                CarroceriaId = 123, 
                Color = "Verde", 
                MarcaId = 321, 
                ModeloId = 852 };
            var businessMoq = new BusinessServiceMoq();
            var service = new VehiculoService(context1, businessMoq);

            //Ejecucion
            await service.Insert(vehiculoToInsert);
            var result = await context1.Vehiculos.CountAsync();

            //Verificacion
            Assert.AreEqual(1, result);
        }

    }
}
