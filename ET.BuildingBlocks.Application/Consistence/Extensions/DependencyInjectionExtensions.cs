using ET.BuildingBlocks.Application.Consistence.Abstractions;
using ET.BuildingBlocks.Application.Consistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ET.BuildingBlocks.Application.Consistence.Extensions;

/// <summary>
/// Предоставляет методы расширения для регистрации зависимостей.
/// </summary>
public static class DependencyInjectionExtensions
{
    /// <summary>
    /// Регистрирует единицу работы
    /// </summary>
    /// <typeparam name="TDbContext">Тип контекста базы данных.</typeparam>
    /// <param name="services">Коллекция служб, куда добавляются зависимости.</param>
    public static void RegisterUnitOfWork<TDbContext>(this IServiceCollection services) where TDbContext : DbContext
    {
        services.AddScoped<IUnitOfWork, UnitOfWork<TDbContext>>();
    }
}