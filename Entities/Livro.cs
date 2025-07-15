public class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }

    public int AutorId { get; set; } // Chave estrangeira
    public virtual Autor Autor { get; set; } // Propriedade de navegação

    public int GeneroId { get; set; } // Chave estrangeira
    public virtual Genero Genero { get; set; } // Propriedade de navegação
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }
}