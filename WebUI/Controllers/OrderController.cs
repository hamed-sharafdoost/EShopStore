using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository order;
        public OrderController(IOrderRepository order)
        {
            this.order = order;
        }
        //Get all orders
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return order.GetAll();
        }
        //Get by Id
        [HttpPost]
        [Route("GetById")]
        public Order GetById(int Id)
        {
            return order.GetById(Id);
        }
        //Get orders by date
        [HttpPost]
        [Route("Getbydate")]
        public IEnumerable<Order> GetByDate(DateTime date)
        {
            return order.GetOrdersByDate(date);
        }
        //Get orders by price
        [HttpPost]
        [Route("Getbyprice")]
        public IEnumerable<Order> GetByPrice(double price)
        {
            return order.GetOrdersByPrice(price);
        }
        //Add new Order
        [HttpPost]
        [Route("Add")]
        public void Add(Order _order)
        {
            order.Add(_order);
        }
        //Delete an order
        [HttpDelete]
        [Route("Delete")]
        public void Delete(int Id)
        {
            order.Delete(Id);
        }
        //Update an order
        [HttpPut]
        [Route("Update")]
        public void Update(Order _order)
        {
            order.Update(_order);
        }
    }
}
