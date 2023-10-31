using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Repositories.Interfaces;

namespace TesteCalculoSeguro.Application.Services;

public class SeguroService : ISeguroService
{
    private const decimal MARGEM_SEGURANCA = 0.03M;
    private const decimal LUCRO = 0.05M;
    private readonly ISeguroRepository _seguroRepository;
    private readonly IVeiculoRepository _veiculoRepository;


    public SeguroService(ISeguroRepository seguroRepository, IVeiculoRepository veiculoRepository)
    {
        _seguroRepository = seguroRepository;
        _veiculoRepository = veiculoRepository;
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

    public async Task<IEnumerable<Veiculo>> ObterVeiculos()
    {
        var veiculos = await _veiculoRepository.ObterVeiculos();
        return veiculos;
    }

    public async Task<IEnumerable<Seguro>> ObterSeguro()
    {
        var seguro = await _seguroRepository.ObterSeguro();
        return seguro;
    }

    public async Task AdicionarVeiculos(Veiculo veiculos)
    {
        await _veiculoRepository.AdicionarVeiculos(veiculos);
        
    }

    public Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade)
    {
        return _seguroRepository.AdicionarSeguro(valorDoVeiculo, marcaDoVeiculo, modeloDoVeiculo, nome, cpf, idade);
    }

    public Task AdicionarSeguro(Seguro seguro)
    {
        throw new NotImplementedException();
    }
}
