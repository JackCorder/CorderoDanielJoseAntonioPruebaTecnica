using CorderoDanielJoseAntonioPruebaTecnica.DTOs;
using CorderoDanielJoseAntonioPruebaTecnica.Models;
using CorderoDanielJoseAntonioPruebaTecnica.Services;
using CorderoDanielJoseAntonioPruebaTecnica.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorderoDanielJoseAntonioPruebaTecnica.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductCreateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var success = await _productService.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _productService.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}
