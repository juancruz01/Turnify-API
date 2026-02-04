using Microsoft.EntityFrameworkCore;
using Turnify.Application.Interfaces.Repositories;
using Turnify.Infrastructure.Persistence;
using Turnify.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Base de Datos
builder.Services.AddDbContext<TurnifyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//INYECCIÓN DE DEPENDENCIAS
//(Cuando alguien pida IUserRepository, dale UserRepository)
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

//Configurar Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();