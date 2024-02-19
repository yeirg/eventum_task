using ET.Domain.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.Infrastructure.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    // HUETA
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.OwnsOne(c => c.Brand, brand =>
        {
            brand.Property(b => b.Value).HasColumnName(nameof(BrandName)).IsRequired();
            brand.HasIndex(b => b.Value).IsUnique();
        }).Navigation(c => c.Brand).IsRequired();

        builder.OwnsOne(c => c.Model, model =>
        {
            model.Property(m => m.Value).HasColumnName(nameof(ModelName)).IsRequired();
            //model.HasIndex(m => m.Value).IsUnique();
        });

        builder.HasOne(c => c.Color)
            .WithMany()
            .HasForeignKey("ColorId")
            .IsRequired();
        
        builder.Property(c => c.CreatedAt).HasColumnType("timestamp without time zone");
        builder.Property(c => c.UpdatedAt).HasColumnType("timestamp without time zone");
    }
}