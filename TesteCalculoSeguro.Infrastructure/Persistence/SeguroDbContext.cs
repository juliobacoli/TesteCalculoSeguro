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
        public DbSet<Seguro> Seguro { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segurado>(x =>
            {
                x.HasKey(k => k.Cpf);

            });

            modelBuilder.Entity<Veiculo>(x =>
            {
                x.HasKey(k => k.Id);
            });

            modelBuilder.Entity<Seguro>(x =>
            {
                x.HasKey(k => k.Id);

            });

            modelBuilder.Entity<Seguro>()
                        .Property(s => s.ValorSeguro)
                        .HasColumnType("decimal(18, 2)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JULIOAVELL-PC;Database=Seguro;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
