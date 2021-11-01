using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBank.Domain.Core.Entities;

namespace XBank.Domain.Infra.Configs
{
    public class MovementConfiguration : EntityConfiguration<Movement>
    {
        public override void Configure(EntityTypeBuilder<Movement> builder)
        {
            base.Configure(builder);

            builder.ToTable("TB_MOVEMENT");

            builder
                .Property(movement => movement.MovementValue)
                .HasColumnName("VL_MOVEMENT_VALUE");

            builder
                .Property(movement => movement.CPFSend)
                .HasColumnName("NR_CPF_SEND");

            builder
                .Property(movement => movement.Type)
                .HasColumnName("NM_TYPE");

            builder
                .Property(movement => movement.AccountId)
                .HasColumnName("ID_ACCOUNT");

            builder
                .HasOne(movement => movement.Account)
                .WithMany(account => account.Movements)
                .HasForeignKey(movement => movement.AccountId);
        }
    }
}
