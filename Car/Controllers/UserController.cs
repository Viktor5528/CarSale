﻿using Car.Entity;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepo _user;
        public UserController(IUserRepo user)
        {
            _user = user;
        }
        [HttpGet]
        public List<User> GetAll()
        {
            return _user.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_user.GetById(id));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _user.Delete(id);
        }

        [HttpPost]
        public int Create(int age, string name, string login, string password)
        {
            return _user.Create(new User { Age = age, Name = name, Login = login, Password = password });
        }
        [HttpPut]
        public void Update(User user)
        {
            _user.Update(user);
        }

    }
}