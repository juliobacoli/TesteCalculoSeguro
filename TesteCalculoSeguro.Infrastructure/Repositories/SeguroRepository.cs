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

        public async Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo,
                                          string nome, string cpf, int idade, decimal valorSeguro)
        {
            Veiculo veiculo = new Veiculo(valorDoVeiculo, marcaDoVeiculo, modeloDoVeiculo);

            Segurado segurado = new Segurado
            {
                Nome = nome,
                Cpf = cpf,
                Idade = idade
            };

            Seguro seguro = new Seguro
            {
                Veiculo = veiculo,
                Segurado = segurado,
                ValorSeguro = valorSeguro
            };

            await _dbContext.Seguro.AddAsync(seguro);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Seguro>> ObterSeguro()
        {
            var seguros = await _dbContext.Seguro
                                        .Include(s => s.Veiculo)
                                        .Include(s => s.Segurado)
                                        .ToListAsync();
            return seguros;
        }

        public async Task ObterCalculoAritmetica()
        {
            await Task.Delay(100);
        }

        public async Task SalvarValorSeguro(decimal valorSeguro)
        {

            Seguro seguro = new Seguro
            {
                ValorSeguro = valorSeguro
            };

            await _dbContext.Seguro.AddAsync(seguro);
            await _dbContext.SaveChangesAsync();
        }
    }
}
