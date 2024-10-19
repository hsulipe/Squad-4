using CadastroCashbackApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCashbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Simulando uma base de dados
        private static List<Usuario> produtos = new List<Usuario>
        {
            new Usuario { Id = 1, Nome = "Produto 1", Email = "test@email.com" },
            new Usuario { Id = 2, Nome = "Produto 2", Email = "test1@email.com" }
        };

        // GET: api/produto
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(produtos);
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = produtos.Find(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST: api/produto
        [HttpPost]
        public IActionResult Post([FromBody] Usuario produto)
        {
            produtos.Add(produto);
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        // PUT: api/produto/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Usuario produtoAtualizado)
        {
            var produto = produtos.Find(p => p.Id == id);

            if (produto == null)
                return NotFound();

            produto.Nome = produtoAtualizado.Nome;
            produto.Email = produtoAtualizado.Email;

            return NoContent();
        }

        // DELETE: api/produto/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = produtos.Find(p => p.Id == id);

            if (produto == null)
                return NotFound();

            produtos.Remove(produto);

            return NoContent();
        }
    }
}