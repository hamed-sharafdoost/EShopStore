using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Fullprice { get; set; }
        public string Address { get; set; }
        public DateTime Creationtime { get; set; }
        public string phonenumber { get; set; }
        public string? Email { get; set; }
        public int UserId { get; set; }
    }
}
