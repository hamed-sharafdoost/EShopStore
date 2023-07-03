using ApplicationCore.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MainContext _context;
        public CommentRepository(MainContext context)
        {
            _context = context;
        }

        public void Add(ApplicationCore.Entities.Comment comment)
        {
            _context.Comments.Add(comment.Adapt<Comment>());
            _context.SaveChanges();
        }

        public void Delete(int productId, int userId)
        {
            _context.Comments.Remove(_context.Comments
                .SingleOrDefault(x => x.UserId == userId && x.ProductId == productId));
            _context.SaveChanges();
            
        }

        public IEnumerable<ApplicationCore.Entities.Comment> GetAll()
        {
            return _context.Comments.AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.Comment>>();
        }

        public IEnumerable<ApplicationCore.Entities.Comment> GetByProductId(int productId)
        {
            return _context.Comments.Where(v => v.ProductId == productId).AsEnumerable()
                   .Adapt<IEnumerable<ApplicationCore.Entities.Comment>>();
        }

        public IEnumerable<ApplicationCore.Entities.Comment> GetByUserId(int userId)
        {
            return _context.Comments.Where(v => v.UserId == userId).AsEnumerable()
                   .Adapt<IEnumerable<ApplicationCore.Entities.Comment>>();
        }

        public void Update(ApplicationCore.Entities.Comment comment)
        {
            _context.Comments.Update(comment.Adapt<Comment>());
            _context.SaveChanges();
        }
    }
}
