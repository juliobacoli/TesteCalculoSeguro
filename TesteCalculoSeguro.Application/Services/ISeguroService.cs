using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguroService
    {
        IEnumerable<Veiculo> ObterCarros();
        double CalcularValorSeguro(double valorVeiculo);
        double CalcularTaxaDeRisco(double valorVeiculo);
        double CalcularPremioDeRisco(double taxaDeRisco, double valorVeiculo);
        double CalcularPremioPuro(double premioDeRisco);
        double CalcularPremioComercial(double premioPuro);
    }
}
