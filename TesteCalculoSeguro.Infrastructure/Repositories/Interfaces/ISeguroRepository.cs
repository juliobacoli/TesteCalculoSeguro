using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Repositories.Interfaces
{
    public interface ISeguroRepository
    {
        Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade, decimal valorSeguro);
        Task<IEnumerable<Segurado>> ObterSegurado();
        Task<List<Seguro>> ObterSeguro();
    }
}