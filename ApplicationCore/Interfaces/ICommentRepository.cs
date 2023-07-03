using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICommentRepository
    {
        public void Delete(int productId,int userId);
        public void Add(Comment comment);
        public IEnumerable<Comment> GetByUserId(int userId);
        public IEnumerable<Comment> GetByProductId(int productId);
        public void Update(Comment comment);
        public IEnumerable<Comment> GetAll();
    }
}
