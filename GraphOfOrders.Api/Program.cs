using GraphOfOrders.Repo.IoC;
using GraphOfOrders.Service.IoC;
using GraphOfOrders.Service;
using Microsoft.AspNetCore.Identity;
using GraphOfOrders.Repo;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();
//check this line
builder.Services.AddDbContext<OrdersContext>();
builder.Services.AddIdentityCore<MyUser>()
    .AddEntityFrameworkStores<OrdersContext>()
    .AddApiEndpoints();

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Add services to the container.
builder.Services.AddRepoServices(builder.Configuration);
builder.Services.AddBusinessServices();

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

app.MapIdentityApi<MyUser>();
app.MapGet("/", (ClaimsPrincipal user) => $"Hello {user.Identity!.Name}")
    .RequireAuthorization();
app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }

class MyUser : IdentityUser { }