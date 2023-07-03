using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        //defining custom operations on User entity
        IEnumerable<User> GetUsersByRoleId(int roleId);
        IEnumerable<User> GetAllUserOrders(int userId);
        IEnumerable<User> GetuserShoppingCart(int userId);
        
    }
}
