using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Repositories.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<IEnumerable<Veiculo>> ObterVeiculos();
        Task AdicionarVeiculos(Veiculo veiculos);
    }
}