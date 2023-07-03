using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly IUserRepository user;
        public UserController(IUserRepository user)
        {
            this.user = user;
        }
        // GET: UserController
        [HttpGet]

        public IEnumerable<User> Get()
        {
            return user.GetAll();
        }
        // Get by Id
        [HttpGet]
        [Route("GetById")]
        public User GetId(int Id)
        {
            return user.GetById(Id);
        }
        
        //Get users with their orders
        [HttpPost]
        public IEnumerable<User> GetWithOrders(int userId)
        {
            return user.GetAllUserOrders(userId);
        }
        
        //Get users with their shoppingcarts
        [HttpPost]
        [Route("Shopping")]
        public IEnumerable<User> GetWithShoppingCarts(int userId)
        {
            return user.GetuserShoppingCart(userId);
        }
        //Get users by their roleId
        [HttpPost]
        [Route("Role")]
        public IEnumerable<User> GetByRoleId(int roleId)
        {
            return user.GetUsersByRoleId(roleId);
        }
        //Add new User
        [HttpPost]
        [Route("Add")]
        public void Add(UserModel _user)
        {
            user.Add(_user.Adapt<User>());
        }
        //Delete a user
        [HttpDelete]
        [Route("Delete")]
        public void Delete(int Id)
        {
            user.Delete(Id);
        }
        //Update a user
        [HttpPut]
        [Route("Update")]
        public void Update(UserModel _user)
        {
            user.Update(_user.Adapt<User>());
        }
        
    }
}
