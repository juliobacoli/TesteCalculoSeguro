namespace TesteCalculoSeguro.Domain.Entities;

public class Seguro
{
    public int Id { get; set; }
    public Veiculo Veiculo { get; set; }
    public Segurado Segurado { get; set; }
}
