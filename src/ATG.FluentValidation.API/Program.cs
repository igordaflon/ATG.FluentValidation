using ATG.Core.Mediator;
using ATG.Core;
using MediatR;
using System.Net.NetworkInformation;
using ATG.FluentValidation.Aplicacao.Artistas.Commands;
using FluentValidation.Results;
using ATG.FluentValidation.Aplicacao.Artistas.Handlers;
using ATG.FluentValidation.Dominio.Artistas.Repositorios;
using ATG.FluentValidation.Infra.Artistas.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
     cfg.RegisterServicesFromAssembly(typeof(Ping).Assembly));

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();

builder.Services.AddScoped<IRequestHandler<NovoArtistaCommand, ValidationResult>, ArtistaCommandHandler>();

builder.Services.AddScoped<IArtistaRepositorio, ArtistaRepositorio>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
