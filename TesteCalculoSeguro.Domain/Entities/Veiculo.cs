using System.Text.Json.Serialization;

namespace TesteCalculoSeguro.Domain.Entities;

public class Veiculo
{
    public Veiculo(double valor, string marca, string modelo)
    {
        Valor = valor;
        Marca = marca;
        Modelo = modelo;
    }

    [JsonIgnore]
    public int Id { get; set; }
    public double Valor { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
}
