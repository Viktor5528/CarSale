using AutoMapper;
using Car.Controllers;
using Car.Entity;
using Car.Repositories.Interfaces;
using DataLayer.Entity.EntityViewModel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Car.Test
{
    public class MachineTest
    {
        Mock<IMachineRepo> mockMachine;
        Mock<IBrandRepo> mockBrand;
        IMapper _mapper;
       

        public MachineTest()
        {
            mockMachine = new Mock<IMachineRepo>();
            mockMachine.Setup(x => x.Create(It.IsAny<Machine>())).Returns(() => 1);
            mockBrand = new Mock<IBrandRepo>();

            mockBrand.Setup(x => x.GetById(It.IsAny<int>())).Returns(() => null);
            mockBrand.Setup(x => x.GetById(1)).Returns(new Brand());
            _mapper = AutoMapperHelper.GetMapper();
        }
        [Fact]
        public void CreateWithInvalidBrandId()
        {


            MachineController controller = new MachineController(mockMachine.Object, mockBrand.Object, _mapper);

            var result = controller.Create(new CreateMachineViewModel
            {
                BrandId = -1, BodyType = Enums.BodyType.Coupe, EngineType=Enums.EngineType.Petrol
            }) ;

            Assert.IsType<BadRequestObjectResult>(result);

        }
        [Fact]
        public void CreateSuccessWithNoteExistingBrandId()
        {
            MachineController controller = new MachineController(mockMachine.Object, mockBrand.Object, _mapper);

            var result = controller.Create(new CreateMachineViewModel 
            { 
                BrandId=2, EngineType=Enums.EngineType.Petrol, BodyType=Enums.BodyType.Coupe
            });

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
