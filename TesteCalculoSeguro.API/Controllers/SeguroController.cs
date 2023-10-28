using Microsoft.AspNetCore.Mvc;
using TesteCalculoSeguro.Application.Services;

namespace TesteCalculoSeguro.API.Controllers;

[ApiController]
[Route("api/seguros")]
public class SeguroController : Controller
{
    private readonly ISeguro _seguro;

    [HttpGet]
    public IActionResult ObterCarros()
    {
        var carros = _seguro.ObterCarros();
        return Ok(carros);
    }
}
