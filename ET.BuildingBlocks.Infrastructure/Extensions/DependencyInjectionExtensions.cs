using ET.BuildingBlocks.Domain.Persistence;
using ET.BuildingBlocks.Infrastructure.Persistence;
using ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ET.BuildingBlocks.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterAppDbContext<TDbContext>(
        this IServiceCollection services,
        Action<DbContextOptionsBuilder> options) where TDbContext : DbContext
    {
        services.AddDbContext<TDbContext>(options);
        services.TryAddScoped<DbContext>(provider => provider.GetRequiredService<TDbContext>());
    }
    
    public static void RegisterEfRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    }
    
    private static IServiceCollection RegisterDbContextInterceptor<TDbContextInterceptor>(this IServiceCollection services)
        where TDbContextInterceptor : class, IDbContextInterceptor
    {
        services.TryAddEnumerable(ServiceDescriptor.Scoped<IDbContextInterceptor, TDbContextInterceptor>());
        
        return services;
    }

    /// <summary>
    /// Регестрирует все перехватички аудита сущностей.
    /// </summary>
    public static IServiceCollection RegisterAuditorDbContextInterceptors(this IServiceCollection services)
    {
        services.RegisterDbContextInterceptor<ActorAuditorInterceptor>();
        services.RegisterDbContextInterceptor<TimeAuditorInterceptor>();
        
        return services;
    }
}