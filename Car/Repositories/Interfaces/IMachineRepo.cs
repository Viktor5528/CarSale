using Car.Entity;
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
    }
}
