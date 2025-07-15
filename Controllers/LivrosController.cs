using EADFirstProjectApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EADFirstProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LivrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LivroDto>>> GetLivros()
        {
            return await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Select(l => new LivroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    AutorId = l.AutorId,
                    NomeAutor = l.Autor.Nome,
                    GeneroId = l.GeneroId,
                    NomeGenero = l.Genero.Nome,
                    DataCriacao = l.DataCriacao,
                    DataModificacao = l.DataModificacao
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDto>> GetLivro(int id)
        {
            var livro = await _context.Livros
                .Include(l => l.Autor)
                .Include(l => l.Genero)
                .Select(l => new LivroDto
                {
                    Id = l.Id,
                    Titulo = l.Titulo,
                    AutorId = l.AutorId,
                    NomeAutor = l.Autor.Nome,
                    GeneroId = l.GeneroId,
                    NomeGenero = l.Genero.Nome
                })
                .FirstOrDefaultAsync(l => l.Id == id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpPost]
        public async Task<ActionResult<LivroDto>> PostLivro(CriarLivroDto criarLivroDto)
        {
            // Validação: verificar se o autor e gênero existem
            var autor = await _context.Autores.FindAsync(criarLivroDto.AutorId);
            var genero = await _context.Generos.FindAsync(criarLivroDto.GeneroId);

            if (autor == null) return BadRequest("Autor inválido.");
            if (genero == null) return BadRequest("Gênero inválido.");

            var livro = new Livro
            {
                Titulo = criarLivroDto.Titulo,
                AutorId = criarLivroDto.AutorId,
                GeneroId = criarLivroDto.GeneroId
            };

            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();

            var livroDto = new LivroDto
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                AutorId = autor.Id,
                NomeAutor = autor.Nome,
                GeneroId = genero.Id,
                NomeGenero = genero.Nome
            };

            return CreatedAtAction(nameof(GetLivro), new { id = livro.Id }, livroDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivro(int id, AtualizarLivroDto atualizarLivroDto)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            // Validação: verificar se o novo autor e gênero existem
            var autorExiste = await _context.Autores.AnyAsync(a => a.Id == atualizarLivroDto.AutorId);
            var generoExiste = await _context.Generos.AnyAsync(g => g.Id == atualizarLivroDto.GeneroId);

            if (!autorExiste) return BadRequest("Autor inválido.");
            if (!generoExiste) return BadRequest("Gênero inválido.");

            livro.Titulo = atualizarLivroDto.Titulo;
            livro.AutorId = atualizarLivroDto.AutorId;
            livro.GeneroId = atualizarLivroDto.GeneroId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
