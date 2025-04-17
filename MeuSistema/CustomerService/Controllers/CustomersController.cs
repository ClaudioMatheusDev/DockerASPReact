using Microsoft.AspNetCore.Mvc;
using CustomerService.Models;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly List<Customer> customers = new()
        {
            new Customer { Id = 1, Name = "João" },
            new Customer { Id = 2, Name = "Maria" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(customers);
        }
    }
}
