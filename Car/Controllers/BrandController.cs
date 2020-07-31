using AutoMapper;
using Car.Entity;
using Car.Repositories.Interfaces;
using DataLayer.Entity.EntityViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandRepo _brand;
        IMapper _mapper;
        public BrandController(IBrandRepo brand, IMapper mapper)
        {
            _brand = brand;
            _mapper = mapper;
        }
        [HttpGet]
        public List<Brand> GetAll()
        {
            return _brand.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_brand.GetById(id));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _brand.Delete(id);
        }
        [HttpDelete("ByName/{name}")]
        public void Delete(string name)
        {
            _brand.Delete(name);
        }
        [HttpPost]
        public int Create(CreateBrandViewModel model)
        {
            return _brand.Create(_mapper.Map<Brand>(model));
        }
        [HttpPut]
        public void Update(Brand brand)
        {
            _brand.Update(brand);
        }
    }
}
