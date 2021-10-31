using Microsoft.EntityFrameworkCore;
using XBank.Domain.Core.Entities;
using XBank.Domain.Infra.Configs;

namespace XBank.Domain.Infra.Contexts
{
    public class XBankContext : DbContext
    {
        public XBankContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountConfiguration().Configure(modelBuilder.Entity<Account>());
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
