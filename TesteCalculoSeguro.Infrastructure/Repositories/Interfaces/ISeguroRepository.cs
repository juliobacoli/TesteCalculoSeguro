﻿using TesteCalculoSeguro.Domain.Entities;

namespace TesteCalculoSeguro.Infrastructure.Repositories.Interfaces
{
    public interface ISeguroRepository
    {
        Task AdicionarSeguro(double valorDoVeiculo, string marcaDoVeiculo, string modeloDoVeiculo, string nome, string cpf, int idade);
        Task ObterCalculoAritmetica();
        Task<List<Seguro>> ObterSeguro();
    }
}