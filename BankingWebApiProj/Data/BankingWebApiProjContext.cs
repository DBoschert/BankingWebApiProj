using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BankingWebApi.Models;
using BankingWebApiProj.Models;

namespace BankingWebApiProj.Data
{
    public class BankingWebApiProjContext : DbContext
    {
        public BankingWebApiProjContext (DbContextOptions<BankingWebApiProjContext> options)
            : base(options)
        {
        }

        public DbSet<BankingWebApi.Models.Account> Accounts { get; set; } = default!;

        public DbSet<BankingWebApi.Models.Customer> Customers { get; set; } = default!;

        public DbSet<BankingWebApiProj.Models.Transaction> Transactions { get; set; } = default!;
    }
}
