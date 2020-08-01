using AutoMapper;
using Car.Controllers;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Car.Test
{
    public class UserTest
    {
        Mock<IUserRepo> mockUser = new Mock<IUserRepo>();
        IMapper _mapper;
        public UserTest()
        {
            _mapper = AutoMapperHelper.GetMapper();
            mockUser.Setup(x => x.GetById(6)).Returns(() =>
            {
                return new Entity.User { };
            });
        }
        [Fact]
        public void GetByIdWithInvalidUserId()
        {
            UserController controller = new UserController(mockUser.Object, _mapper);
            var result = controller.GetById(2);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
