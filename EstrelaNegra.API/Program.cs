using EstrelaNegra.API.Applications;
using EstrelaNegra.API.Controllers;
using EstrelaNegra.API.Interfaces;
using EstrelaNegra.API.Mappings;
using EstrelaNegra.API.Models;
using EstrelaNegra.API.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HENContext>(x => x.UseSqlServer(connectionString));

#region Dependency Injection
builder.Services.AddScoped<IHorseRepository, HorseRepository>();
builder.Services.AddScoped<IHorseApplication, HorseApplication>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserApplication, UserApplication>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));


#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
