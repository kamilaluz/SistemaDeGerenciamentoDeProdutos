using GerenciamentoDeProdutos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Produto> ListarProdutos()
        {
            var produtos = _context.Produtos.ToList();

            return produtos;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProtudo(Produto produto)
        {
            var produtoCadastrado = await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return Created(nameof(ListarProdutos), new { id = produtoCadastrado.Entity.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> AtualizarProduto(int id, [FromBody]  Produto produto)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);

            if(produtoExistente == null)
            {
                return NotFound(new { Message = "Produto inexistente" });
            }
            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.QuantidadeEstoque = produto.QuantidadeEstoque;
            await _context.SaveChangesAsync();

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> Excluir(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if(produto == null)
            {
                return NotFound(new { Message = "Produto inexistente" });
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
