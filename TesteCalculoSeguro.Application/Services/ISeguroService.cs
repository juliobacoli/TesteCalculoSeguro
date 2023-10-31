using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguroService
    {
        Task<IEnumerable<Veiculo>> ObterVeiculos();
        Task<IEnumerable<Seguro>> ObterSeguro();
        Task<IEnumerable<Veiculo>> AdicionarVeiculos(Veiculo veiculos);
        decimal CalcularValorSeguro(decimal valorVeiculo);
        decimal CalcularTaxaDeRisco(decimal valorVeiculo);
        decimal CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo);
        decimal CalcularPremioPuro(decimal premioDeRisco);
        decimal CalcularPremioComercial(decimal premioPuro);
    }
}
