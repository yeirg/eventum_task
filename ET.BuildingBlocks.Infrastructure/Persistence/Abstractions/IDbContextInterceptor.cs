using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ET.BuildingBlocks.Infrastructure.Persistence.Abstractions;

/// <summary>
/// Предоставляет методы для перехвата операций перед и после сохранения изменений в контексте базы данных.
/// </summary>
public interface IDbContextInterceptor
{
    /// <summary>
    /// Вызывается перед сохранением изменений в контексте базы данных.
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    void BeforeSave(EntityEntry entry);
}