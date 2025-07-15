using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Livro> Livros { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Genero> Generos { get; set; }
}