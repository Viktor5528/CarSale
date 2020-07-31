using Car.Entity;
using Car.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Car.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        Context db;
        public CommentRepo(Context context)
        {
            db = context;
        }
        public int Create(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            return comment.Id;
        }
        public void Delete(int id)
        {
            var comment = db.Comments.FirstOrDefault(x => x.Id == id);
            db.Comments.Remove(comment);
            db.SaveChanges();
        }
        public void Update(Comment comment)
        {
            db.Comments.Update(comment);
            db.SaveChanges();
        }
        public List<Comment> GetAll()
        {
            return db.Comments.ToList();
        }
        public Comment GetById(int id)
        {
            return db.Comments.FirstOrDefault(x => x.Id == id);

        }
    }
}
