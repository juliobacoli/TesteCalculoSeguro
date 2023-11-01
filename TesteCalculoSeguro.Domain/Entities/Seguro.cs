using System.Text.Json.Serialization;

namespace TesteCalculoSeguro.Domain.Entities;

public class Seguro
{
    [JsonIgnore]
    public int Id { get; set; }
    public Veiculo Veiculo { get; set; }
    public Segurado Segurado { get; set; }
    public decimal ValorSeguro { get; set; }
}
