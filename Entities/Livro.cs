public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public int AutorId { get; set; } // Chave estrangeira - só lembrete
    public virtual Autor Autor { get; set; } 

    public int GeneroId { get; set; } // Chave estrangeira - só lembrete 
    public virtual Genero Genero { get; set; } 
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }
}