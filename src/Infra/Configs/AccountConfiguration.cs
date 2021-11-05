using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Infra.Configs
{
    public class AccountConfiguration : EntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_ACCOUNT");

            builder
                .Property(account => account.Balance)
                .HasColumnType("money")
                .HasColumnName("VL_BALANCE");

            builder
                .Property(account => account.ClientId)
                .HasColumnName("ID_CLIENT");

            builder
                .HasOne(account => account.Client)
                .WithOne(client => client.Account)
                .HasForeignKey<Account>(account => account.ClientId);

            builder
                .Property(account => account.ClientId)
                .HasColumnName("ID_CLIENT");

        }
    }
}
