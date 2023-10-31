using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguroService
    {
        Task<IEnumerable<Veiculo>> ObterVeiculos();
        Task<IEnumerable<Seguro>> ObterSeguro();
        Task AdicionarVeiculos(Veiculo veiculos);
        Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade);
        decimal CalcularValorSeguro(decimal valorVeiculo);
        decimal CalcularTaxaDeRisco(decimal valorVeiculo);
        decimal CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo);
        decimal CalcularPremioPuro(decimal premioDeRisco);
        decimal CalcularPremioComercial(decimal premioPuro);
        
    }
}
