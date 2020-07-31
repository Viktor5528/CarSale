using Car.Entity;
using System.Collections.Generic;

namespace Car.Repositories.Interfaces
{
    public interface ICommentRepo
    {
        int Create(Comment comment);
        void Delete(int id);
        void Update(Comment comment);
        List<Comment> GetAll();
        Comment GetById(int id);
    }
}
