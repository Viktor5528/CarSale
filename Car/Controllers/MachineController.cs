using AutoMapper;
using Car.Entity;
using Car.Enums;
using Car.Repositories.Interfaces;
using DataLayer.Entity.EntityViewModel;
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
        IMapper _mapper;
        public MachineController(IMachineRepo machine, IBrandRepo brand, IMapper mapper)
        {
            _machine = machine;
            _brand = brand;
            _mapper = mapper;
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
        public IActionResult Create(CreateMachineViewModel model)
        {
            if (model.BrandId <= 0 || _brand.GetById(model.BrandId) == null)
            {
                return BadRequest("Message");
            }
            return Ok(_machine.Create(_mapper.Map<Machine>(model)));
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
