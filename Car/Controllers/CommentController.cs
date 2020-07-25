using Car.Entity;
using Car.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentRepo _comment;
        public CommentController(ICommentRepo comment)
        {
            _comment = comment;
        }
        [HttpGet]
        public List<Comment> GetAll()
        {
            return _comment.GetAll();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_comment.GetById(id));
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _comment.Delete(id);
        }

        [HttpPost]
        public int Create(string message, int userId, int machineId)
        {
            return _comment.Create(new Comment { MachineId = machineId, Message = message, UserId = userId });
        }
        [HttpPut]
        public void Update(Comment comment)
        {
            _comment.Update(comment);
        }
        [HttpGet("message")]
        public string GetMessage(Comment comment)
        {
            return comment.Message;
        }
    }
}
