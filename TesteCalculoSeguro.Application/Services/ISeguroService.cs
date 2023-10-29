using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguroService
    {
        IEnumerable<Veiculo> ObterCarros();
        decimal CalcularValorSeguro(decimal valorVeiculo);
        decimal CalcularTaxaDeRisco(decimal valorVeiculo);
        decimal CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo);
        decimal CalcularPremioPuro(decimal premioDeRisco);
        decimal CalcularPremioComercial(decimal premioPuro);
    }
}
