using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Dtos.ProductDto> Products = new()
        {
            new Dtos.ProductDto(Guid.NewGuid(), "Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new Dtos.ProductDto(Guid.NewGuid(), "Termék2", 5500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new Dtos.ProductDto(Guid.NewGuid(), "Termék3", 12500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
        };

        [HttpGet]
        public List<Dtos.ProductDto> Get()
        {
            return Products;
        }
    }
}
