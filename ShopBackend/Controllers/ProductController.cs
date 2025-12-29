using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBackend.Data;
using ShopBackend.DTOs.Produto;
using ShopBackend.Models;

namespace ShopBackend.Controllers {
    [Route("api/product/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {

        private readonly AppDbContext _context;
        public ProductController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetProducts() {

            var products = await _context.Products
                .Select(p => new ProductReadDto {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Barcode = p.Barcode,
                    Brand = p.Brand
                })
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProductsPerId(int id) {

            var produto = await _context.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductReadDto {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    StockQuantity = p.StockQuantity,
                    Barcode = p.Barcode,
                    Brand = p.Brand,
                })
                .FirstOrDefaultAsync();

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateProduct([FromBody] ProductCreateDto dto) {

            var product = new ProductModel {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                Barcode = dto.Barcode,
                Brand = dto.Brand,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var readDto = new ProductReadDto {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Barcode = product.Barcode,
                Brand = product.Brand
            };

            return CreatedAtAction(
                nameof(GetProductsPerId),
                new { id = readDto.Id },
                readDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProductCreateDto dto) {

            var produto = await _context.Products.FindAsync(id);

            if (produto == null)
                return NotFound();

            produto.Name = dto.Name;
            produto.Description = dto.Description;
            produto.Price = dto.Price;
            produto.StockQuantity = dto.StockQuantity;
            produto.Barcode = dto.Barcode;
            produto.Brand = dto.Brand;
            produto.UpdatedAt = DateTime.UtcNow;

            _context.Entry(produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduct(int id, [FromBody] ProductPatchDto dto) {

            var produto = await _context.Products.FindAsync(id);

            if (produto == null)
                return NotFound();
            if (dto.Name != null)
                produto.Name = dto.Name;
            if (dto.Description != null)
                produto.Description = dto.Description;
            if (dto.Price.HasValue)
                produto.Price = dto.Price.Value;
            if (dto.StockQuantity.HasValue)
                produto.StockQuantity = dto.StockQuantity.Value;

            produto.UpdatedAt = DateTime.UtcNow;

            _context.Entry(produto).State = EntityState.Modified;


            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id) {

            var produto = await _context.Products.FindAsync(id);

            if (produto == null)
                return NotFound();
            _context.Products.Remove(produto);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

