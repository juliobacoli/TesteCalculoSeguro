using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TesteCalculoSeguro.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("TesteCalculoSeguro");
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
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
