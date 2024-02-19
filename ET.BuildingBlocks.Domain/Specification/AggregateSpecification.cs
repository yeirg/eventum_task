using Ardalis.Specification;

namespace ET.BuildingBlocks.Domain.Specification;

/// <summary>
/// Базовая спецификация для деклораций общих функций
/// </summary>
public class AggregateSpecification<TAggregateRoot, TKey> : EntitySpecification<TAggregateRoot, TKey>
    where TAggregateRoot : AggregateRoot<TKey>
{
}

/// <summary>
/// Перегрузка, принимает агрегат с ключем типа Guid как параметр тип
/// </summary>
public class AggregateSpecification<TAggregateRoot> : AggregateSpecification<TAggregateRoot, Guid>
    where TAggregateRoot : AggregateRoot<Guid>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public AggregateSpecification()
    {
    }
    
    /// <summary>
    /// Получение сущности по id.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <returns>Экземпляр класса AggregateSpecification, настроенный для фильтрации по id.</returns>
    public AggregateSpecification<TAggregateRoot, Guid> ById(Guid id)
    {
        Query.Where(aggregate => aggregate.Id == id);

        return this;
    }
}