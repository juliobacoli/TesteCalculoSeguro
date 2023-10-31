using Microsoft.EntityFrameworkCore;
using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Persistence;
using TesteCalculoSeguro.Infrastructure.Repositories.Interfaces;

namespace TesteCalculoSeguro.Infrastructure.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly SeguroDbContext _dbContext;


        public VeiculoRepository(SeguroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AdicionarVeiculos(Veiculo veiculos)
        {
            await _dbContext.AddAsync(veiculos);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Veiculo>> ObterVeiculos()
        {
            var veiculos = await _dbContext.Veiculo.ToListAsync();
            return veiculos;
        }
    }
}
