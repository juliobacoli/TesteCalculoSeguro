using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteCalculoSeguro.Application.Services;
using TesteCalculoSeguro.Infrastructure.Persistence;
using TesteCalculoSeguro.Infrastructure.Repositories;
using TesteCalculoSeguro.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("TesteCalculoSeguroDb");
builder.Services.AddDbContext<SeguroDbContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TesteCalculoSeguroAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Julio Bacoli",
            Email = "juliosantanabacoli@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/julio-bacoli/")
        }
    });

});

builder.Services.AddScoped<ISeguroService, SeguroService>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
