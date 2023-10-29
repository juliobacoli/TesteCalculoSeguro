using Microsoft.AspNetCore.Mvc;
using TesteCalculoSeguro.Application.Services;
using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.API.Controllers;

[ApiController]
[Route("api/seguros")]
public class SeguroController : Controller
{
    private readonly ISeguroService _seguro;

    [HttpGet("obterCarros")]
    public async Task<IActionResult> ObterCarros()
    {
        var carros = _seguro.ObterCarros();
        return Ok(carros);
    }

    [HttpGet("segurado")]
    public async Task<IActionResult> ObterSegurado()
    {
        var segurado = new Segurado()
        {
            Nome = "John Doe",
            Cpf = "123.456.789-10",
            Idade = 20
        };

        return Ok(segurado);
    }
}
