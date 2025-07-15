using System.Collections.Generic;

public class Autor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<Livro> Livros { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataModificacao { get; set; }

    public Autor()
    {
        Livros = new List<Livro>();
    }

}