using Microsoft.EntityFrameworkCore;
using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Persistence
{
    public class SeguroDbContext : DbContext
    {
        public SeguroDbContext(DbContextOptions<SeguroDbContext> options) : base(options) { }

        public DbSet<Segurado> Segurado { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Segurado.Add(new Segurado
            {
                Nome = "João Silva",
                Cpf = "123.456.789-00",
                Idade = 30
            });
        }
    }
}
