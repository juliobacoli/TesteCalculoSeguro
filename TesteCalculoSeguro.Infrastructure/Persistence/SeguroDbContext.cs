using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Persistence
{
    public class SeguroDbContext : DbContext
    {
        public SeguroDbContext() { }

        public SeguroDbContext(DbContextOptions<SeguroDbContext> options) : base(options) { }

        public DbSet<Segurado> Segurado { get; set; }
        public DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segurado>(x =>
            {
                x.HasKey(k => k.Cpf);

            });              

            Segurado.Add(new Segurado
            {
                Nome = "João Silva",
                Cpf = "123.456.789-00",
                Idade = 30
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
