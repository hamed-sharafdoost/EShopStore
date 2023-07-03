using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/Comment")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository comment;
        public CommentController(ICommentRepository _comment)
        {
            comment = _comment;
        }
        //Get all comments
        [HttpGet]
        public IEnumerable<Comment> GetAll()
        {
            return comment.GetAll();
        }
        //Get by userId
        [HttpPost]
        [Route("GeyById")]
        public IEnumerable<Comment> GetById(int userId)
        {
            return comment.GetByUserId(userId);
        }
        //Get by productId
        [HttpPost]
        [Route("GetByproductId")]
        public IEnumerable<Comment> GetByproductId(int productId)
        {
            return comment.GetByProductId(productId);
        }
        //Add a comment
        [HttpPost]
        [Route("AddComment")]
        public void Add(Comment ncomment)
        {
            comment.Add(ncomment);
        }
        //Delete a comment
        [HttpDelete]
        [Route("DeleteComment")]
        public void Delete(int userId,int productId)
        {
            comment.Delete(userId,productId);
        }
        //Update a comment
        [HttpPut]
        [Route("UpdateComment")]
        public void Update(Comment ncomment)
        {
            comment.Update(ncomment);
        }
    }
}
