using Application.Interfaces;
using Application.Services;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceServices, ServiceServices >();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();



// Adding DbContext
builder.Services.AddDbContext<OMSDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection"))
);

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