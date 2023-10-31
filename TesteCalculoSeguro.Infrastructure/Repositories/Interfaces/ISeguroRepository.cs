using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Repositories.Interfaces
{
    public interface ISeguroRepository
    {
        Task<IEnumerable<Seguro>> ObterSeguro();
    }
}