using OnRepository.EFCore.WebAPI.Sample.Data;
using Microsoft.EntityFrameworkCore;
using OnRepository.EFCore.WebAPI.Sample.Repositories;
using OnRepository.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddDbContext<AppDbContext>(options
    => options.UseInMemoryDatabase("AppDbContext"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerKindRepository, CustomerKindRepository>();

builder.Services.AddScoped<IUnitOfWork, AppDbContext>();



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
