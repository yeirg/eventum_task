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
            color.Property(b => b.Value).HasColumnName("name").IsRequired();
            color.HasIndex(b => b.Value).IsUnique();
        });

        builder.HasMany(c => c.Cars)
            .WithOne(c => c.Color);
    }
}