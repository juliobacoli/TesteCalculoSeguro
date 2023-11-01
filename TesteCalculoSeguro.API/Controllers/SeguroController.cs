using Microsoft.AspNetCore.Mvc;
using TesteCalculoSeguro.Application.Services;
using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.API.Controllers;

[ApiController]
[Route("api/seguros")]
public class SeguroController : Controller
{
    private readonly ISeguroService _seguroService;

    public SeguroController(ISeguroService seguro)
    {
        _seguroService = seguro;
    }

    [HttpGet("obterVeiculos")]
    public async Task<IActionResult> ObterVeiculos()
    {
        var carros = await _seguroService.ObterVeiculos();
        if (carros == null)
        {
            return NotFound();
        }
        return Ok(carros);
    }

    [HttpGet("obterSegurado")]
    public async Task<IActionResult> ObterSegurado()
    {
        var segurado = await _seguroService.ObterSegurado();
        if (segurado == null)
        {
            return NotFound();
        }

        return Ok(segurado);
    }

    [HttpGet("valorSeguro")]
    public Task<decimal> ObterCauculoValorSeguro(decimal valorVeiculo)
    {
        var valor = _seguroService.CalcularValorSeguro(valorVeiculo);
        return valor;
    }

    [HttpGet("obterSeguro")]
    public async Task<IActionResult> ObterSeguro()
    {
        var seguro = await _seguroService.ObterSeguro();
        if (seguro == null)
        {
            return NotFound(); 
        }
        return Ok(seguro);
    }

    [HttpPost("adicionarVeiculo")]
    public async Task<IActionResult> AdicionarVeiculos(Veiculo veiculos)
    {
        await _seguroService.AdicionarVeiculos(veiculos);
        return Ok();
    }

    [HttpPost("adicionarSeguro")]
    public async Task<IActionResult> AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade, decimal valorSeguro)
    {
        await _seguroService.AdicionarSeguro(valorDoVeiculo, marcaDoVeiculo, modeloDoVeiculo, nome, cpf, idade, valorSeguro);
        return Ok();
    }
}
