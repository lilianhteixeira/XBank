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
            new ClientConfiguration().Configure(modelBuilder.Entity<Client>());
            new MovementConfiguration().Configure(modelBuilder.Entity<Movement>());
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
