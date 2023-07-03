using ApplicationCore.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Encryption;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        HashingPassword hash = new HashingPassword();
        private User user { get; set; }
        private readonly MainContext _context;
        public UserRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(ApplicationCore.Entities.User entity)
        {
            entity.Password = hash.HashPassword(entity.Password);
            entity.SaltText = hash.Salt;
            _context.Users.Add(entity.Adapt<User>());
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            user = _context.Users.SingleOrDefault(v => v.UserId == Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationCore.Entities.User> GetAll()
        {
            return _context.Users.ToList().Adapt<IList<ApplicationCore.Entities.User>>();
        }

        public ApplicationCore.Entities.User GetById(int Id)
        {
            return _context.Users.SingleOrDefault(x => x.UserId == Id).Adapt<ApplicationCore.Entities.User>();
        }

        public IEnumerable<ApplicationCore.Entities.User> GetUsersByRoleId(int roleId)
        {
            return _context.Users.Where(x => x.UserRoleId == roleId).AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.User>>();
        }

        public void Update(ApplicationCore.Entities.User entity)
        {
            _context.Users.Update(entity.Adapt<User>());
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationCore.Entities.User> GetAllUserOrders(int userId)
        {
            return _context.Users.Include(v => v.Orders).Where(x => x.UserId == userId).AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.User>>();
        }

        public IEnumerable<ApplicationCore.Entities.User> GetuserShoppingCart(int userId)
        {
            return _context.Users.Where(x => x.UserId == userId).Include(b => b.ShoppingCarts).AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.User>>();
        }
    }
}
