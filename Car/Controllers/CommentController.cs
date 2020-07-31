using AutoMapper;
using Car.Entity;
using Car.Repositories.Interfaces;
using DataLayer.Entity.EntityViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentRepo _comment;
        IMapper _mapper;
        public CommentController(ICommentRepo comment, IMapper mapper)
        {
            _comment = comment;
            _mapper = mapper;
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
        public int Create(CreateCommentViewModel model)
        {
            return _comment.Create(_mapper.Map<Comment>(model));
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
