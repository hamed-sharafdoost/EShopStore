using ApplicationCore.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MainContext _context;
        public OrderRepository(MainContext context)
        {
            _context = context;
        }
        public void Add(ApplicationCore.Entities.Order entity)
        {
            _context.Orders.Add(entity.Adapt<Order>());
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            _context.Orders.Remove(_context.Orders.SingleOrDefault(b => b.OrderId == Id));
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationCore.Entities.Order> GetAll()
        {
            return _context.Orders.AsEnumerable().Adapt<IEnumerable<ApplicationCore.Entities.Order>>();
        }

        public ApplicationCore.Entities.Order GetById(int Id)
        {
            return _context.Orders.SingleOrDefault(b => b.OrderId == Id).Adapt<ApplicationCore.Entities.Order>();
        }

        public IEnumerable<ApplicationCore.Entities.Order> GetOrdersByDate(DateTime date)
        {
            return _context.Orders.Where(b => b.Creationtime == date)
                .AsEnumerable()
                .Adapt<IEnumerable<ApplicationCore.Entities.Order>>();
        }

        public IEnumerable<ApplicationCore.Entities.Order> GetOrdersByPrice(double price)
        {
            return _context.Orders.Where(b => b.Fullprice == price)
                .AsEnumerable()
                .Adapt<IEnumerable<ApplicationCore.Entities.Order>>();
        }
        public void Update(ApplicationCore.Entities.Order entity)
        {
            _context.Orders.Update(entity.Adapt<Order>());
            _context.SaveChanges();
        }
    }
}
