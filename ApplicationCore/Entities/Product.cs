using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int? WarehouseCode { get; set; }
        public Dictionary<string, string>? Attributes { get; set; } = new Dictionary<string, string>();
        public string? ImagePath { get; set; }
        public double? Price { get; set; }
        public string? Tag { get; set; }
        public string? Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int Count { get; set; }
        public double? Discount { get; set; }
        public bool CommentEnabled { get; set; }
        public int? CategoryId { get; set; }
        public int? CreatorId { get; set; }
    }
}
