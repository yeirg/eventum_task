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
            brand.Property(b => b.Value).HasColumnName("brand_name").IsRequired();
        }).Navigation(c => c.Brand).IsRequired();

        builder.OwnsOne(c => c.Model, model =>
        {
            model.Property(m => m.Value).HasColumnName("model_name").IsRequired();
            //model.HasIndex(m => m.Value).IsUnique();
        }).Navigation(c => c.Model).IsRequired();

        builder.HasOne(c => c.Color)
            .WithMany()
            .HasForeignKey("h_color_id")
            .IsRequired();
        
        builder.Property(c => c.CreatedAt).HasColumnType("timestamp with time zone");
        builder.Property(c => c.UpdatedAt).HasColumnType("timestamp with time zone");
    }
}