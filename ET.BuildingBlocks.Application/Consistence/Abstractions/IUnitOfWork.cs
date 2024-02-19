namespace ET.BuildingBlocks.Application.Consistence.Abstractions;

/// <summary>
/// Предоставляет метод для асинхронного сохранения изменений в единице работы.
/// </summary>
public interface IUnitOfWork 
{
    /// <summary>
    /// Асинхронно сохраняет все изменения в единице работы.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены для отмены задачи.</param>
    /// <returns>Задача, представляющая асинхронную операцию сохранения.</returns>
    Task CommitAsync(CancellationToken cancellationToken = default);
}