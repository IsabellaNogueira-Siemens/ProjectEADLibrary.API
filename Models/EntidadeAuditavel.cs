namespace EADFirstProjectApi.Models
{
    public abstract class EntidadeAuditavel
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}
