using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguroService
    {
        Task<IEnumerable<Veiculo>> ObterVeiculos();
        Task<IEnumerable<Seguro>> ObterSeguro();
        Task AdicionarVeiculos(Veiculo veiculos);
        Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade);
        Task<decimal> CalcularValorSeguro(decimal valorVeiculo);
        Task<decimal> CalcularTaxaDeRisco(decimal valorVeiculo);
        Task<decimal> CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo);
        Task<decimal> CalcularPremioPuro(decimal premioDeRisco);
        Task<decimal> CalcularPremioComercial(decimal premioPuro);
        
    }
}
