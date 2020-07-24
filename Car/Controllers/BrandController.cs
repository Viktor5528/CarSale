using Car.Entity;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandRepo _brand;
        public BrandController(IBrandRepo brand)
        {
            _brand = brand;
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
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            _brand.Delete(name);
        }
        [HttpPost]
        public int Create(Brand brand)
        {
            return _brand.Create(brand);
        }
    }
}
