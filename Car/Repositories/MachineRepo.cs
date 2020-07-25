using Car.Entity;
using Car.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Car.Repositories
{
    public class MachineRepo : IMachineRepo
    {
        Context db;
        public MachineRepo(Context context)
        {
            db = context;
        }
        public int Create(Machine machine)
        {
            db.Machines.Add(machine);
            db.SaveChanges();
            return machine.Id;
        }
        public void Delete(int id)
        {
            var machine = db.Machines.FirstOrDefault(x => x.Id == id);
            db.Machines.Remove(machine);
            db.SaveChanges();
        }
        public void Update(Machine machine)
        {
            db.Machines.Update(machine);
            db.SaveChanges();
        }
        public List<Machine> GetAll()
        {
            return db.Machines.ToList();
        }
        public Machine GetById(int id)
        {
            return db.Machines.FirstOrDefault(x => x.Id == id);
        }
    }
}