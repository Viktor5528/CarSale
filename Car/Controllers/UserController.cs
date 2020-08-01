using AutoMapper;
using Car.Entity;
using Car.Repositories.Interfaces;
using DataLayer.Entity.EntityViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo _user;
        IMapper _mapper;
        public UserController(IUserRepo user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }
        [HttpGet]
        public List<User> GetAll()
        {
            return _user.GetAll();
        }
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public IActionResult GetById(int id)
        {
            if (_user.GetById(id) == null || id>5)
            {
                return BadRequest("message");
            }
            return Ok(_user.GetById(id));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _user.Delete(id);
        }

        [HttpPost]
        public int Create(CreateUserViewModel model)
        {
            return _user.Create(_mapper.Map<User>(model));
        }
        [HttpPut]
        public void Update(User user)
        {
            _user.Update(user);
        }

    }
}
