using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Persistence;

namespace TesteCalculoSeguro.Application.Services
{
    public class Seguro : ISeguro
    {
        private readonly SeguroDbContext _dbContext;

        public Seguro(SeguroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Veiculo> ObterCarros()
        {
            var veiculos = _dbContext.Veiculo;
            return veiculos;
        }
    }
}
