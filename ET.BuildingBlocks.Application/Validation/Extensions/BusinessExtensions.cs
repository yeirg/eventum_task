using ET.BuildingBlocks.Domain;
using ET.BuildingBlocks.Error.Exceptions.Business;

namespace ET.BuildingBlocks.Application.Validation.Extensions;

public static class BusinessExtensions
{
    /// <summary>
    /// Проверяет, существует ли объект, и в случае его отсутствия генерирует исключение.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, для которой выполняется проверка.</typeparam>
    /// <param name="obj">Объект, который нужно проверить.</param>
    /// <param name="id">Идентификатор объекта для генерации сообщения об ошибке, если объект не найден.</param>
    /// <returns>Объект, если он существует.</returns>
    /// <exception cref="EntityNotFoundException">Исключение, если объект не найден.</exception>
    public static TEntity EnsureExists<TEntity>(this TEntity? obj, Guid id) 
        where TEntity : Entity<Guid>
    {
        return obj ?? throw new EntityNotFoundException(nameof(TEntity), id, "Not found", "ENTITY NOT FOUND");
    }
        
    /// <summary>
    /// Асинхронная версия метода EnsureExists. Проверяет, существует ли объект в результате асинхронной операции.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, для которой выполняется проверка.</typeparam>
    /// <param name="task">Задача, возвращающая объект, который нужно проверить.</param>
    /// <param name="id">Идентификатор объекта для генерации сообщения об ошибке, если объект не найден.</param>
    /// <returns>Объект, если он существует, в результате асинхронной операции.</returns>
    /// <exception cref="EntityNotFoundException">Исключение, если объект не найден.</exception>
    public static async Task<TEntity> EnsureExistsAsync<TEntity>(this Task<TEntity?> task, Guid id) 
        where TEntity : Entity<Guid>
    {
        return await task ?? throw new EntityNotFoundException(nameof(TEntity), id, "Not found", "ENTITY NOT FOUND");
    }
}