using UnitTesting = Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TesteCalculoSeguro.Application.Services;
using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Repositories.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteCalculoSeguto.UnitTests;

public class SeguroServiceTest
{
    private SeguroService _seguroService;
    private readonly Mock<ISeguroRepository> _seguroRepository;
    private readonly Mock<IVeiculoRepository> _veiculoRepository;

    public SeguroServiceTest()
    {
        _seguroRepository = new Mock<ISeguroRepository>();
        _veiculoRepository = new Mock<IVeiculoRepository>();
        _seguroService = new SeguroService(_seguroRepository.Object, _veiculoRepository.Object);
    }

    [TestMethod]
    public async Task ObterSeguro_Sucesso()
    {
        var listaSeguros = new List<Seguro>();
        listaSeguros.Add(new Seguro()
        {
            Id = 1,
            Veiculo = new Veiculo(10, "Dodge", "Mustang"),
            Segurado = new Segurado()
            {
                Cpf = "111.222.333-44",
                Idade = 20,
                Nome = "Fulano"
            }
        });

        _seguroRepository.Setup(x => x.ObterSeguro()).ReturnsAsync(listaSeguros);

        var resultado = _seguroService.ObterSeguro();

        UnitTesting.Assert.IsNotNull(resultado.Result);
    }

    [TestMethod]
    public async Task ObterSeguro_Erro()
    {
        var listaSeguros = new List<Seguro>();

        _seguroRepository.Setup(x => x.ObterSeguro()).ReturnsAsync(listaSeguros);

        var resultado = _seguroService.ObterSeguro();

        UnitTesting.Assert.AreEqual(resultado.Result.Count(), 0);
    }
}
