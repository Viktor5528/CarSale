using Car.Entity;
using Car.Enums;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        IMachineRepo _machine;
        IBrandRepo _brand;
        public MachineController(IMachineRepo machine, IBrandRepo brand)
        {
            _machine = machine;
            _brand = brand;
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
        public IActionResult Create(int brandId, BodyType bodyType, EngineType engineType)
        {
            if (brandId <= 0 || _brand.GetById(brandId) == null)
            {
                return BadRequest("Message");
            }
            return Ok(_machine.Create(new Machine { BrandId = brandId, BodyType = bodyType, EngineType = engineType }));
        }
        [HttpPut]
        public void Update(Machine machine)
        {
            _machine.Update(machine);
        }
        [HttpGet("comments")]
        public List<Comment> GetAllComments(int machineId)
        {
            var machine = _machine.GetById(machineId);
            return machine.Comments;
        }
        [HttpGet("filter")]
        public List<Machine> GetAllFilter(BodyType? body, EngineType? engine, int? brandId)
        {
            return _machine.GetAllFilter(body, engine, brandId);
        }
    }
}
