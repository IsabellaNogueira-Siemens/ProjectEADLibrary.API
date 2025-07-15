namespace EADFirstProjectApi.Models
{
    public class Livro : EntidadeAuditavel
    {
        public string? Titulo { get; set; }

        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }

        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
    }
}
