namespace ET.BuildingBlocks.Domain;

public abstract class TimeAuditableAggregateRoot<TKey> : AggregateRoot<TKey>, ITimeAuditable
{
    /// <summary>
    /// Получает или задает время создания агрегата.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Получает или задает время последнего обновления агрегата.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Представляет абстрактный класс для агрегатов с типом идентификатора <see cref="Guid"/>, отслеживающих время создания и последнего обновления.
/// </summary>
public abstract class TimeAuditableAggregateRoot : TimeAuditableAggregateRoot<Guid>
{
    
}
