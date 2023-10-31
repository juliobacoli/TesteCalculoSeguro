using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

    [HttpGet("segurado")]
    public IActionResult ObterSegurado()
    {
        var segurado = new Segurado()
        {
            Nome = "John Doe",
            Cpf = "123.456.789-10",
            Idade = 20
        };

        return Ok(segurado);
    }

    [HttpGet("valorSeguro")]
    public decimal ObterValorSeguro(decimal valorVeiculo)
    {
        var valor = _seguroService.CalcularValorSeguro(valorVeiculo);

        return valor;
    }

    [HttpGet("obterSeguro")]
    public IActionResult ObterSeguro()
    {
        var seguro = _seguroService.ObterSeguro();
        if (seguro == null)
        {
            return NotFound(); 
        }
        return Ok(seguro);
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarVeiculos(Veiculo veiculos)
    {
        var resultado = await _seguroService.AdicionarVeiculos(veiculos);
        return Ok(resultado);
    }
}
