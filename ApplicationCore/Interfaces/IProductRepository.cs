using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByname(string name);
        IEnumerable<Product> GetProductsInorder(string name = null);
        IEnumerable<Product> GetProductsByPrice(double price);
        Product GetProductByWarehousecode(int code);
        IEnumerable<Product> GetProductsByCtgId(int ctgId);
        IEnumerable<Product> GetProductByAttributes(string attributes, string value);
        IEnumerable<Product> GetProductByDate(DateTime date);
        IEnumerable<Product> GetProductWithDiscount();
    }
}
