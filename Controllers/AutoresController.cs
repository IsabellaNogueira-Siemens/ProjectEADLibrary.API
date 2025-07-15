using EADFirstProjectApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EADFirstProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorDto>>> GetAutores()
        {
            return await _context.Autores
                .Select(a => new AutorDto { 
                    Id = a.Id, 
                    Nome = a.Nome, 
                    DataCriacao = a.DataCriacao, 
                    DataModificacao = a.DataModificacao 
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutor(int id)
        {
            var autor = await _context.Autores
                .Select(a => new AutorDto { Id = a.Id, Nome = a.Nome })
                .FirstOrDefaultAsync(a => a.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public async Task<ActionResult<AutorDto>> PostAutor(CriarAutorDto criarAutorDto)
        {
            var autor = new Autor { Nome = criarAutorDto.Nome };

            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            var autorDto = new AutorDto { Id = autor.Id, Nome = autor.Nome };

            return CreatedAtAction(nameof(GetAutor), new { id = autor.Id }, autorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, CriarAutorDto criarAutorDto)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            autor.Nome = criarAutorDto.Nome;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            var autorEmUso = await _context.Livros.AnyAsync(l => l.AutorId == id);
            if (autorEmUso)
            {
                return BadRequest("Não é possível excluir um autor que está associado a um ou mais livros.");
            }

            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
