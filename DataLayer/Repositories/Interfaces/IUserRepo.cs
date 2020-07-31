using Car.Entity;
using System.Collections.Generic;

namespace Car.Repositories.Interfaces
{
    public interface IUserRepo
    {
        int Create(User user);
        void Delete(int id);
        void Update(User user);

        List<User> GetAll();
        User GetById(int id);

    }
}
