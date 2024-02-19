using ET.Domain.CarColors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.Infrastructure.Configurations;

public class CarColorConfiguration : IEntityTypeConfiguration<CarColor>
{
    public void Configure(EntityTypeBuilder<CarColor> builder)
    {
        builder.OwnsOne(c => c.Color, color =>
        {
            color.Property(b => b.Value).HasColumnName(nameof(Color)).IsRequired();
            color.HasIndex(b => b.Value).IsUnique();
        });
    }
}