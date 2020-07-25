using Car.Entity;
using Car.Enums;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        IMachineRepo _machine;
        public MachineController(IMachineRepo machine)
        {
            _machine = machine;
        }
        [HttpGet]
        public List<Machine> GetAll()
        {
            return _machine.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_machine.GetById(id));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _machine.Delete(id);
        }

        [HttpPost]
        public int Create(int brandId, BodyType bodyType, EngineType engineType)
        {
            return _machine.Create(new Machine { BrandId = brandId, BodyType = bodyType, EngineType = engineType });
        }
        [HttpPut]
        public void Update(Machine machine)
        {
            _machine.Update(machine);
        }
        [HttpGet("comments")]
        public List<Comment> GetAllComments(Machine machine)
        {
            return machine.Comments.ToList();
        }
    }
}
