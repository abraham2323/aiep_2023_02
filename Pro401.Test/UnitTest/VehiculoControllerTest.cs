using Microsoft.AspNetCore.Mvc;
using Moq;
using Pro401.Controllers;
using Pro401.DTO.VehiculoDTO;
using Pro401.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro401.Test.UnitTest
{
    [TestClass]
    public class VehiculoControllerTest : BaseTest
    {
        [TestMethod]
        public async Task Post_Return_PatenteExiste()
        {
            //Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExiste(It.IsAny<string>())).ReturnsAsync(true);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO { Patente = "dswr", CarroceriaId = 0, Color = "gris", MarcaId = 0, ModeloId = 0, Id = 0};

            //Ejecucion
            var result = await controller.Post(vehiculo);

            //Verificacion
            Assert.IsTrue(result is BadRequestObjectResult);
        }

        [TestMethod]
        public async Task Post_Return_PrimeraLetraMayuscula()
        {
            //Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExiste(It.IsAny<string>())).ReturnsAsync(false);
            vehiculoService.Setup(x => x.PrimeraLetraMayuscula(It.IsAny<string>())).Returns(false);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO { Patente = "dswr", CarroceriaId = 0, Color = "gris", MarcaId = 0, ModeloId = 0, Id = 0 };

            //Ejecucion
            var result = await controller.Post(vehiculo);

            //Verificacion
            Assert.IsTrue(result is BadRequestObjectResult);
            Assert.AreEqual("La primera letra debe ser MAYUSCULA", ((BadRequestObjectResult)result).Value);
        }

        [TestMethod]
        public async Task Post_Return_Ok()
        {
            //Preparacion
            var vehiculoService = new Mock<IVehiculoService>();
            vehiculoService.Setup(x => x.PatenteExiste(It.IsAny<string>())).ReturnsAsync(false);
            vehiculoService.Setup(x => x.PrimeraLetraMayuscula(It.IsAny<string>())).Returns(true);
            var mapper = BuildMapper();
            var controller = new VehiculoController(vehiculoService.Object, mapper);
            var vehiculo = new VehiculoCreateDTO { Patente = "dswr", CarroceriaId = 0, Color = "gris", MarcaId = 0, ModeloId = 0, Id = 0 };

            //Ejecucion
            var result = await controller.Post(vehiculo);

            //Verificacion
            Assert.IsTrue(result is OkObjectResult);
            Assert.AreEqual("Registro guardado", ((OkObjectResult)result).Value);
        }
    }
}
