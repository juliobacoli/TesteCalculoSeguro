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

        }
    }
}
