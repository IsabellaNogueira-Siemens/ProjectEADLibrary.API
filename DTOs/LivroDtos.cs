namespace EADFirstProjectApi.DTOs
{
    // DTO para exibir um livro com os nomes do autor e gênero
    public class LivroDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public int AutorId { get; set; }
        public string? NomeAutor { get; set; }
        public int GeneroId { get; set; }
        public string? NomeGenero { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }

    // DTO para criar um novo livro
    public class CriarLivroDto
    {
        public string? Titulo { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }

    // DTO para atualizar um livro
    public class AtualizarLivroDto
    {
        public string? Titulo { get; set; }
        public int AutorId { get; set; }
        public int GeneroId { get; set; }
    }
}
