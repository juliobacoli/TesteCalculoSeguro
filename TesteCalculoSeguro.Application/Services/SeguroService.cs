using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Persistence;

namespace TesteCalculoSeguro.Application.Services
{
    public class SeguroService : ISeguroService
    {
        private const double MARGEM_SEGURANCA = 0.03;
        private const double LUCRO = 0.05;
        private readonly SeguroDbContext _dbContext;

        public SeguroService(SeguroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public double CalcularTaxaDeRisco(double valorVeiculo)
        {
            return (valorVeiculo * 5) / (2 * valorVeiculo);
        }

        public double CalcularPremioDeRisco(double taxaDeRisco, double valorVeiculo)
        {
            return taxaDeRisco * valorVeiculo;
        }

        public double CalcularPremioPuro(double premioDeRisco)
        {
            return premioDeRisco * (1 + MARGEM_SEGURANCA);
        }

        public double CalcularPremioComercial(double premioPuro)
        {
            return LUCRO * premioPuro;
        }

        public double CalcularValorSeguro(double valorVeiculo)
        {
            double taxaDeRisco = CalcularTaxaDeRisco(valorVeiculo);
            double premioDeRisco = CalcularPremioDeRisco(taxaDeRisco, valorVeiculo);
            double premioPuro = CalcularPremioPuro(premioDeRisco);

            return CalcularPremioComercial(premioPuro);
        }

        public IEnumerable<Veiculo> ObterCarros()
        {
            var veiculos = _dbContext.Veiculo;
            return veiculos;
        }
    }
}
