using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BankingWebApiProj.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BankingWebApiProjContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingWebApiProjContext") ?? throw new InvalidOperationException("Connection string 'BankingWebApiProjContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
