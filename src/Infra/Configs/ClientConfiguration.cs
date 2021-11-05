using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBank.Domain.Core.Entities;
using XBank.Domain.Shared.ValueObjects;

namespace XBank.Domain.Infra.Configs
{
    public class ClientConfiguration : EntityConfiguration<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_CLIENT");

            builder
                .HasIndex(client => client.CPF, "IX_CPF")
                .IsUnique();

            builder
                .Property(client => client.Name)
                .HasColumnName("NM_NAME");

            builder
                .Property(client => client.CPF)
                .HasColumnName("DS_CPF");
                //.HasConversion(
                //  cpf => cpf.Value,
                //  valorDoBanco => new CPF(valorDoBanco)
                // );

            builder
                .Property(client => client.Email)
                .HasColumnName("NM_EMAIL");

            builder
                .Property(client => client.Address)
                .HasColumnName("NM_ADDRESS");

            builder
                .Property(client => client.Phone)
                .HasColumnName("NR_PHONE");

        }
    }
}
