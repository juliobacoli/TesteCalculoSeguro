namespace TesteCalculoSeguro.Domain.Entities
{
    public class Veiculo
    {
        public Veiculo(int id, double valor, string marca, string modelo)
        {
            Id = id;
            Valor = valor;
            Marca = marca;
            Modelo = modelo;
        }

        public int Id { get; set; }
        public double Valor { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
    }
}
