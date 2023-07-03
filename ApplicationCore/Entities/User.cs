using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? SaltText { get; set; }
        public string? Address { get; set; }
        public string? phonenumber { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserRoleId { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
