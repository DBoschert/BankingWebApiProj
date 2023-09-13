using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BankingWebApiProj.Data;
using BankingWebApi.Models;

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

// TEST
/*
var newCheckingAcct = new Account() {
    Id = 0,
    Description = "new checking account",
    InterestRate = 0,
    Balance = 100,
    CreatedDate = DateTime.Now,
    ModifiedDate = DateTime.Now,
    CustomerId

};
*/