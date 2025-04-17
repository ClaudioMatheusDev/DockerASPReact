using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Produto> products = new()
        {
            new Produto { Id = 1, Name = "Notebook", Price = 3000.00M },
            new Produto { Id = 2, Name = "Mouse", Price = 50.00M },
            new Produto { Id = 3, Name = "Teclado", Price = 100.00M }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(products);
        }
    }
}
