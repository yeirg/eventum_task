using Ardalis.Specification;

namespace ET.BuildingBlocks.Domain.Persistence;

/// <summary>
/// Определяет интерфейс репозитория для работы с агрегатами, имеющими идентификатор типа Guid.
/// </summary>
public interface IRepository<TAggregate> : IRepository<TAggregate, Guid>
    where TAggregate : AggregateRoot<Guid>
{
    // Так как этот интерфейс является расширением интерфейса IRepository<TAggregate, Guid>,
    // специфические методы или свойства в этом интерфейсе отсутствуют.
}

/// <summary>
/// Определяет интерфейс репозитория для работы с агрегатами.
/// </summary>
/// <typeparam name="TAggregateRoot">Тип агрегата.</typeparam>
/// <typeparam name="TKey">Тип ключа агрегата.</typeparam>
public interface IRepository<TAggregateRoot, TKey> 
    where TAggregateRoot : AggregateRoot<TKey>
{
    /// <summary>
    /// Получает список агрегатов, соответствующих определенной спецификации.
    /// </summary>
    Task<List<TAggregateRoot>> GetListAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получает список моделей, проецированных из агрегатов, соответствующих определенной спецификации.
    /// </summary>
    Task<List<TModel>> GetListAsync<TModel>(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получает первый найденный агрегат, соответствующий спецификации, или null, если таковой не найден.
    /// </summary>
    Task<TAggregateRoot?> GetFirstOrDefaultAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Получает первую найденную модель, проецированную из агрегата, соответствующего спецификации,
    /// или null, если таковая не найдена.
    /// </summary>
    Task<TModel?> GetFirstOrDefaultAsync<TModel>(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Проверяет наличие хотя бы одного агрегата, соответствующего спецификации.
    /// </summary>
    Task<bool> ExistAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Возвращает количество агрегатов, соответствующих спецификации.
    /// </summary>
    Task<int> CountAsync(
        ISpecification<TAggregateRoot>? specification = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновляет предоставленные агрегаты.
    /// </summary>
    Task UpdateAsync(params TAggregateRoot[] aggregateRoots);

    /// <summary>
    /// Добавляет новые агрегаты.
    /// </summary>
    Task AddAsync(params TAggregateRoot[] aggregateRoots);

    /// <summary>
    /// Удаляет предоставленные агрегаты.
    /// </summary>
    Task HardDeleteAsync(params TAggregateRoot[] aggregateRoots);
    
    /// <summary>
    /// Удаляет агрегаты, соответствующие определенной спецификации.
    /// </summary>
    Task HardDeleteAsync(ISpecification<TAggregateRoot> specification);
}