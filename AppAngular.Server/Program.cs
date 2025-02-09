using AppAngular.Server.Models;
using AppAngular.Server.Repositorio;
using AppAngular.Server.RepositorioImp;
using AppAngular.Server.Servicio;
using AppAngular.Server.ServicioImp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Configurar la base de datos
builder.Services.AddDbContext<ModelContext>(options=>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IServicioUsuario, ServicioUsuarioImp>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioImp>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
