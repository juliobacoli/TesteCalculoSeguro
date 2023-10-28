namespace TesteCalculoSeguro.Domain.Entities
{
    public class Segurado
    {
        public Segurado(string nome, string cpf, int idade)
        {
            Nome = nome;
            Cpf = cpf;
            Idade = idade;
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
    }
}
