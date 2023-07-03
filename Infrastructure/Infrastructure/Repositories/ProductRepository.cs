using ApplicationCore.Interfaces;
using AutoMapper;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MainContext _context;
        private Product product { get; set; }
        public ProductRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(ApplicationCore.Entities.Product entity)
        {
            _context.Products.Add(entity.Adapt<Product>());
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _context.Products.Remove(_context.Products.SingleOrDefault(b => b.ProductId == Id));
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetAll()
        {
            return _context.Products.ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public ApplicationCore.Entities.Product GetById(int Id)
        {
            return _context.Products.SingleOrDefault(b => b.ProductId == Id).Adapt<ApplicationCore.Entities.Product>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductByAttributes(string attributes, string value)
        {
            return _context
                .Products
                .Select(x => x.Attributes.Select(v => v.Key == attributes && v.Value == value))
                .ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductByDate(DateTime date)
        {
            return _context
                .Products
                .Select(x => x.CreationTime.Equals(date))
                .ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public ApplicationCore.Entities.Product GetProductByWarehousecode(int code)
        {
            return _context
                .Products
                .SingleOrDefault(b => b.WarehouseCode == code)
                .Adapt<ApplicationCore.Entities.Product>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductsByCtgId(int ctgId)
        {
            return _context
                .Products
                .Select(x => x.CategoryId == ctgId)
                .ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductsByname(string name)
        {
            return _context
                .Products
                .Select(v => v.Name == name)
                .ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductsByPrice(double price)
        {
            return _context
                .Products
                .Select(c => c.Price == price)
                .ToList().Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductsInorder(string name = null)
        {
            if(name == null)
                return _context.Products.Adapt<IList<ApplicationCore.Entities.Product>>();
            else
                return _context.Products.Select(v => v.Name == name).Adapt<IList<ApplicationCore.Entities.Product>>();
        }

        public void Update(ApplicationCore.Entities.Product entity)
        {
            _context.Products.Update(entity.Adapt<Infrastructure.Product>());
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationCore.Entities.Product> GetProductWithDiscount()
        {
            return _context.Products.Where(b => b.Discount > 0).AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.Product>>();
        }
    }
}
