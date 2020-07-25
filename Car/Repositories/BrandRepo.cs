using Car.Entity;
using Car.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Car.Repositories
{
    public class BrandRepo : IBrandRepo
    {
        Context db;
        public BrandRepo(Context context)
        {
            db = context;
        }
        public int Create(Brand brand)
        {
            db.Brands.Add(brand);
            db.SaveChanges();
            return brand.Id;
        }
        public Brand GetById(int Id)
        {
            return db.Brands.FirstOrDefault(x => x.Id == Id);
        }
        public List<Brand> GetAll()
        {
            return db.Brands.ToList();
        }
        public void Update(Brand brand)
        {
            db.Update(brand);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var brand = db.Brands.FirstOrDefault(x => x.Id == id);
            if (brand != null)
            {
                db.Brands.Remove(brand);
                db.SaveChanges();
            }
        }
        public void Delete(string name)
        {
            var brand = db.Brands.FirstOrDefault(x => x.Name == name);
            if (brand != null)
            {
                db.Brands.Remove(brand);
                db.SaveChanges();
            }
        }
    }
}
