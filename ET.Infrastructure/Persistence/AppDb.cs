using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;
using ET.Domain.CarColors;
using ET.Domain.Cars;
using ET.Domain.Users;
using ET.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.Persistence;

public class AppDb : ApplicationDbContext
{
    public AppDb(DbContextOptions<AppDb> options, 
        IEnumerable<IDbContextInterceptor>? interceptors = null) : base(options, interceptors)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarColor> CarColors { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new CarColorConfiguration());
    }
}