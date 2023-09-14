using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Dtos.ProductDto> Products = new()
        {
            new Dtos.ProductDto(Guid.NewGuid(), "Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new Dtos.ProductDto(Guid.NewGuid(), "Termék2", 5500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
            new Dtos.ProductDto(Guid.NewGuid(), "Termék3", 12500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow)
        };

        private JsonSerializerOptions opts = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok($"{{\"success\": true, \"data\": {JsonSerializer.Serialize(Products, opts)}}}");
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var dto = Products.Find(x => x.Id == id);
            if (dto != null)
            {
                Products.Remove(dto);
                return Ok($"{{\"success\": true, \"data\": {JsonSerializer.Serialize(dto, opts)}}}");
            }

            return NotFound("{\"success\": false, \"data\": \"Nem létezik a megadott ID!\"}");
        }

        [HttpPost]
        public IActionResult Post(Dtos.CreateObjectDto dto)
        {
            var obj = new Dtos.ProductDto(Guid.NewGuid(), dto.ProductName, dto.ProductPrice, DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow);
            Products.Add(obj);
            return Ok($"{{\"success\": true, \"data\": {JsonSerializer.Serialize(obj, opts)}}}");
        }

        [HttpPut]
        public IActionResult PullProduct(Guid id, Dtos.UpdateProductDto updateProduct)
        {
            var dto = Products.First(x => x.Id == id);
            var newDto = dto with
            {
                ProductPrice = updateProduct.ProductPrice,
                ProductName = updateProduct.ProductName,
                ModifiedTime = DateTimeOffset.UtcNow
            };
            Products[Products.FindIndex(x => x.Id == id)] = newDto;
            
            return Ok($"{{\"success\": true, \"data\": {JsonSerializer.Serialize(dto, opts)}}}");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var dto = Products.Find(x => x.Id == id);
            if (dto != null)
            { 
                Products.Remove(dto);
                return Ok("{\"success\": true, \"data\": \"A törlés sikeres volt!\"}");
            }

            return NotFound("{\"success\": false, \"data\": \"Nem létezik a megadott ID!\"}");
        }
    }
}
