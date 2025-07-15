namespace EADFirstProjectApi.DTOs
{
    public class AutorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }

    public class CriarAutorDto
    {
        public string Nome { get; set; }
    }
}