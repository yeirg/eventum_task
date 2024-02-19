using ET.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ET.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.OwnsOne(u => u.Login, login =>
        {
            login.Property(l => l.Value).HasColumnName(nameof(Login)).IsRequired();
            login.HasIndex(l => l.Value).IsUnique();
        }).Navigation(u => u.Login).IsRequired();
        
        builder.OwnsOne(u => u.PasswordHash, p => p
            .Property(q => q.Value)
            .HasColumnName(nameof(PasswordHash))
            .IsRequired()).Navigation(u => u.PasswordHash).IsRequired();
        
        builder.Property(q => q.CreatedAt).HasColumnType("timestamp without time zone");
        builder.Property(q => q.UpdatedAt).HasColumnType("timestamp without time zone");
    }
}