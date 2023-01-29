using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("/store")]
    public class StoreTestController : Controller
    {
        ProductRepository product = new ProductRepository();
        [HttpGet]
        public IEnumerable<ApplicationCore.Entities.Product> Get()
        {
            return product.GetAll();
        }
    }
}
