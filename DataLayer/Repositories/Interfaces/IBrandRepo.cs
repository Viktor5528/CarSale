using Car.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Repositories.Interfaces
{
    public interface IBrandRepo
    {
        int Create(Brand brand);
        Brand GetById(int Id);
        void Delete(string name);
        void Delete(int id);
        void Update(Brand brand);
        List<Brand> GetAll();
    }
}
