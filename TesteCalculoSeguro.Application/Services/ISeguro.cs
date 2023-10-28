using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Application.Services
{
    public interface ISeguro
    {
        IEnumerable<Veiculo> ObterCarros();
    }
}
