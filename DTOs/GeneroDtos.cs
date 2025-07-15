namespace EADFirstProjectApi.DTOs
{
    public class GeneroDto
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }

    public class CriarGeneroDto
    {
        public string? Nome { get; set; }
    }
}
