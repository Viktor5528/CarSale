using Car.Controllers;
using Car.Entity;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace Car.Test
{
    public class MachineTest
    {
        Mock<IMachineRepo> mockMachine;
        Mock<IBrandRepo> mockBrand;
        public MachineTest()
        {
            mockMachine = new Mock<IMachineRepo>();
            mockMachine.Setup(x => x.Create(It.IsAny<Machine>())).Returns(() => 1);
            mockBrand = new Mock<IBrandRepo>();
            
            mockBrand.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            mockBrand.Setup(x => x.GetById(1)).Returns(new Brand());
        }
        [Fact]
        public void CreateWithInvalidBrandId()
        {

            MachineController controller = new MachineController(mockMachine.Object, mockBrand.Object);

            var result = controller.Create(-1, (Enums.BodyType.Coupe) -1, Enums.EngineType.Diesel);

            Assert.IsType<BadRequestObjectResult>(result);

        }
        [Fact]
        public void CreateSuccessWithNoteExistingBrandId()
        {
            MachineController controller = new MachineController(mockMachine.Object, mockBrand.Object);

            var result = controller.Create(2, Enums.BodyType.Coupe, Enums.EngineType.Diesel);

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
