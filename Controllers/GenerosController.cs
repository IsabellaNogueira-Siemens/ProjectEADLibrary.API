using EADFirstProjectApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> GetGeneros()
        {
            return await _context.Generos
                .Select(g => new GeneroDto { Id = g.Id, Nome = g.Nome })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroDto>> GetGenero(int id)
        {
            var genero = await _context.Generos
                .Select(g => new GeneroDto { 
                    Id = g.Id, 
                    Nome = g.Nome, 
                    DataCriacao = g.DataCriacao,
                    DataModificacao = g.DataModificacao
                })
                .FirstOrDefaultAsync(g => g.Id == id);

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        [HttpPost]
        public async Task<ActionResult<GeneroDto>> PostGenero(CriarGeneroDto criarGeneroDto)
        {
            var genero = new Genero { Nome = criarGeneroDto?.Nome };

            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            var generoDto = new GeneroDto { Id = genero.Id, Nome = genero.Nome };

            return CreatedAtAction(nameof(GetGenero), new { id = genero.Id }, generoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, CriarGeneroDto criarGeneroDto)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            genero.Nome = criarGeneroDto.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            var genero = await _context.Generos.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }

            var generoEmUso = await _context.Livros.AnyAsync(l => l.GeneroId == id);
            if (generoEmUso)
            {
                return BadRequest("N�o � poss�vel excluir um g�nero que est� associado a um ou mais livros.");
            }

            _context.Generos.Remove(genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}