using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "This will return a list of products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return "This will return product";
        }
    }
}