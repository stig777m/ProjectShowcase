using DataAccessLayer.Data;
using BussinessLogicLayer.DTOs;
using BussinessLogicLayer.Services;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database
string connectionString = builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString, c => c.MigrationsAssembly("WebApi"))
);

// DI
builder.Services.AddScoped<IProjectRepositories, ProjectRepositories>();
builder.Services.AddScoped<ITicketRepositories, TicketRepositories>();
builder.Services.AddScoped<ITicketServices, TicketServices>();




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
