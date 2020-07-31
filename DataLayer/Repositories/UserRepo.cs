using Car.Entity;
using Car.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Car.Repositories
{
    public class UserRepo : IUserRepo
    {
        Context db;
        public UserRepo(Context context)
        {
            db = context;
        }
        public int Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }
        public void Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }
        public void Update(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
        public List<User> GetAll()
        {
            return db.Users.ToList();
        }
        public User GetById(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

    }
}
