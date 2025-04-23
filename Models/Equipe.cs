namespace jsonDesafio.Models
{
    public class Equipe
    {
        public string? Nome { get; set; }
        public bool Lider { get; set; }
        public List<Projetos>? Projetos { get; set; }
    }
}