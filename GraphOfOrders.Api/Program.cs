using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GraphOfOrders.Api.IoC;
using GraphOfOrders.Repo;
using GraphOfOrders.Repo.IoC;
using GraphOfOrders.Service.IoC;
using GraphOfOrders.Service;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add DbContext 
builder.Services.AddDbContext<AccountingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<OrdersContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRepoServices(builder.Configuration);
builder.Services.AddBusinessServices();
builder.Services.AddValidatorServices();

builder.Services.AddControllers();
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

// Enable CORS
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program
{
}