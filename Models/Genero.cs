namespace EADFirstProjectApi.Models
{
    public class Genero : EntidadeAuditavel // Herda da classe base
    {
        public string? Nome { get; set; }
        public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
    }

}
