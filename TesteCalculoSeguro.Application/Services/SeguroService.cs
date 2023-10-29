using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Persistence;

namespace TesteCalculoSeguro.Application.Services;

public class SeguroService : ISeguroService
{
    private const decimal MARGEM_SEGURANCA = 0.03M;
    private const decimal LUCRO = 5.0M;
    private readonly SeguroDbContext _dbContext;

    public SeguroService(SeguroDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public decimal CalcularTaxaDeRisco(decimal valorVeiculo)
    {
        return (valorVeiculo * 0.5m) / (0.2m * valorVeiculo);
    }

    public decimal CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo)
    {
        taxaDeRisco /= 100; 
        decimal premioDeRisco = taxaDeRisco * valorVeiculo;
        return Math.Round(premioDeRisco, 2); // arredonda o prêmio de risco para duas casas decimais
    }

    public decimal CalcularPremioPuro(decimal premioDeRisco)
    {
        decimal resultado = premioDeRisco * (1 + MARGEM_SEGURANCA);
        return Math.Round(resultado, 2);
    }

    public decimal CalcularPremioComercial(decimal premioPuro)
    {
        return LUCRO * premioPuro;
    }


    public decimal CalcularValorSeguro(decimal valorVeiculo)
    {
        decimal taxaDeRisco = CalcularTaxaDeRisco(valorVeiculo);
        decimal premioDeRisco = CalcularPremioDeRisco(taxaDeRisco, valorVeiculo);
        decimal premioPuro = CalcularPremioPuro(premioDeRisco);
        decimal premioComercial = CalcularPremioComercial(premioPuro);

        return premioComercial;
    }

    public IEnumerable<Veiculo> ObterCarros()
    {
        var veiculos = _dbContext.Veiculo;
        return veiculos;
    }
}
