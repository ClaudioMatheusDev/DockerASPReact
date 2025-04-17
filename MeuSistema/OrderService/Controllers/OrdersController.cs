using Microsoft.AspNetCore.Mvc;
using OrderService.Models;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly List<Order> orders = new()
        {
            new Order { Id = 1, CustomerId = 1, ProductName = "Notebook", Total = 3000.00M },
            new Order { Id = 2, CustomerId = 2, ProductName = "Mouse", Total = 50.00M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Order>> Get()
        {
            return Ok(orders);
        }
    }
}
