using System.Collections.Generic;

public class Genero
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }
}