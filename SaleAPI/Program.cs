using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence;
using Persistence.Contracts.UnitOfWork;
using Persistence.Services.UnitOfWorks;
using Persistence.Contracts.Repository;
using Persistence.Services.Repositories;
using Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using Application;
using Application.CustomerCRUD.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Maps));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddApplication();


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
