using Application.DTOS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Monolithic_Architecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductController(ProductService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll(CancellationToken ct)
            => Ok(await _service.GetAllAsync(ct));

        public record CreateProductRequest(string Name, decimal Price);

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProductRequest req, CancellationToken ct)
        {
            var id = await _service.CreateAsync(req.Name, req.Price, ct);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken ct)
        {
            var all = await _service.GetAllAsync(ct); // simple demo reuse
            var item = all.FirstOrDefault(p => p.Id == id);
            return item is null ? NotFound() : Ok(item);
        }
    }
}
