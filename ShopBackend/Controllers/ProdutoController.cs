using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBackend.Data;
using ShopBackend.DTOs.Produto;
using ShopBackend.Models;

namespace ShopBackend.Controllers {
    [Route("api/produto/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase {

        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoReadDto>>> GetProdutos() {

            var produtos = await _context.Produtos
                .Select(p => new ProdutoReadDto {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    CodigoDeBarras = p.CodigoDeBarras,
                    Marca = p.Marca
                })
                .ToListAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoReadDto>> GetProduto(int id) {

            var produto = await _context.Produtos
                .Where(p => p.Id == id)
                .Select(p => new ProdutoReadDto {
                    Id = p.Id,
                    Nome = p.Nome,
                    Descricao = p.Descricao,
                    Preco = p.Preco,
                    QuantidadeEstoque = p.QuantidadeEstoque,
                    CodigoDeBarras = p.CodigoDeBarras,
                    Marca = p.Marca
                })
                .FirstOrDefaultAsync();

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoReadDto>> CreateProduto([FromBody] ProdutoCreateDto dto) {

            var produto = new ProdutoModel {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                QuantidadeEstoque = dto.QuantidadeEstoque,
                CodigoDeBarras = dto.CodigoDeBarras,
                Marca = dto.Marca
            };

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            var readDto = new ProdutoReadDto {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                QuantidadeEstoque = produto.QuantidadeEstoque,
                CodigoDeBarras = produto.CodigoDeBarras,
                Marca = produto.Marca
            };

            return CreatedAtAction(
                nameof(GetProduto),
                new { id = readDto.Id },
                readDto
            );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProdutoCreateDto dto) {

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.QuantidadeEstoque = dto.QuantidadeEstoque;
            produto.CodigoDeBarras = dto.CodigoDeBarras;
            produto.Marca = dto.Marca;

            _context.Entry(produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchProduto(int id, [FromBody] ProdutoPatchDto dto) {

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();
            if (dto.Nome != null)
                produto.Nome = dto.Nome;
            if (dto.Descricao != null)
                produto.Descricao = dto.Descricao;
            if (dto.Preco.HasValue)
                produto.Preco = dto.Preco.Value;
            if (dto.QuantidadeEstoque.HasValue)
                produto.QuantidadeEstoque = dto.QuantidadeEstoque.Value;

            _context.Entry(produto).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id) {

            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
                return NotFound();
            _context.Produtos.Remove(produto);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
