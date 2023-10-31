using Microsoft.EntityFrameworkCore;
using TesteCalculoSeguro.Domain.Entities;
using TesteCalculoSeguro.Infrastructure.Persistence;
using TesteCalculoSeguro.Infrastructure.Repositories.Interfaces;

namespace TesteCalculoSeguro.Infrastructure.Repositories
{
    public class SeguroRepository : ISeguroRepository
    {
        private readonly SeguroDbContext _dbContext;


        public SeguroRepository(SeguroDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<IEnumerable<Seguro>> ObterSeguro()
        {
            var seguro = await _dbContext.Seguro.ToListAsync();
            return seguro;
        }
    }
}
