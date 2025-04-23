namespace jsonDesafio.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public int Idade { get; set; }
        public int Score { get; set; }
        public bool Ativo { get; set; }
        public string? Pais { get; set; }
        public Equipe? Equipe { get; set; }
        public List<Logs>? Logs { get; set; }
    }
}