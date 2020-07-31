using Car.Entity;
using Car.Enums;
using System.Collections.Generic;

namespace Car.Repositories.Interfaces
{
    public interface IMachineRepo
    {
        int Create(Machine machine);
        void Delete(int id);
        void Update(Machine machine);
        List<Machine> GetAll();
        Machine GetById(int id);
        List<Machine> GetAllFilter(BodyType? body, EngineType? engine, int? brandId);
    }
}
