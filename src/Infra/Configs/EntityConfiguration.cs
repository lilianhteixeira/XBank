using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XBank.Domain.Shared.Entities;

namespace XBank.Domain.Infra.Configs
{
    public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("ID");

            builder
                .Property(x => x.CreatedAt)
                .HasColumnType("SmallDateTime")
                .HasColumnName("DT_CREATED");

            builder
                .Property(x => x.UpdatedAt)
                .HasColumnType("SmallDateTime")
                .HasColumnName("DT_UPDATED");

            builder
                .Property(x => x.IsActive)
                .HasColumnName("ST_ACTIVE");
        }
    }
}
