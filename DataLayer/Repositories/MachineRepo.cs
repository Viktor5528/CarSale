﻿using Car.Entity;
using Car.Enums;
using Car.Repositories.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
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
            return db.Machines.Include(y => y.Comments).FirstOrDefault(x => x.Id == id);
        }
        public List<Machine> GetAllFilter(BodyType? body, EngineType? engine, int? brandId)
        {
            var machines = db.Machines.AsQueryable();
            machines = machines
                .WhereIfCondition(x => x.BodyType == body.Value, body.HasValue)
                .WhereIfCondition(x => x.EngineType == engine.Value, engine.HasValue)
                .WhereIfCondition(x => x.BrandId == brandId.Value, brandId.HasValue);
           
            return machines.ToList();
        }
    }
}