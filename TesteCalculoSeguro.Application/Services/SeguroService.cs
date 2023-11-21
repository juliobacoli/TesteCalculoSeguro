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

    public async Task<decimal> CalcularTaxaDeRisco(decimal valorVeiculo)
    {
        return (valorVeiculo * 0.5m) / (0.2m * valorVeiculo);
    }

    public async Task<decimal> CalcularPremioDeRisco(decimal taxaDeRisco, decimal valorVeiculo)
    {
        taxaDeRisco /= 100; 
        decimal premioDeRisco = taxaDeRisco * valorVeiculo;
        return Math.Round(premioDeRisco, 2); // arredonda o prêmio de risco para duas casas decimais
    }

    public async Task<decimal> CalcularPremioPuro(decimal premioDeRisco)
    {
        decimal resultado = premioDeRisco * (1 + MARGEM_SEGURANCA);
        return Math.Round(resultado, 2);
    }

    public async Task<decimal> CalcularPremioComercial(decimal premioPuro)
    {
        return (LUCRO * premioPuro) + premioPuro;
    }


    public async Task<decimal> CalcularValorSeguro(decimal valorVeiculo)
    {
        decimal taxaDeRisco = await CalcularTaxaDeRisco(valorVeiculo);
        decimal premioDeRisco = await CalcularPremioDeRisco(taxaDeRisco, valorVeiculo);
        decimal premioPuro = await CalcularPremioPuro(premioDeRisco);
        decimal premioComercial = await CalcularPremioComercial(premioPuro);

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

    public async Task<IEnumerable<Segurado>> ObterSegurado()
    {
        var segurado = await _seguroRepository.ObterSegurado();
        return segurado;
    }

    public async Task AdicionarVeiculos(Veiculo veiculos)
    {
        _veiculoRepository.AdicionarVeiculos(veiculos);
        
    }

    public async Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade, decimal valorSeguro)
    {
        _seguroRepository.AdicionarSeguro(valorDoVeiculo, marcaDoVeiculo, modeloDoVeiculo, nome, cpf, idade, valorSeguro);
    }

}
