namespace ET.BuildingBlocks.Domain;

public abstract class TimeAuditableEntity<TKey> : Entity<TKey>, ITimeAuditable
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TimeAuditableEntity{TKey}"/> с указанными датами создания и обновления.
    /// </summary>
    /// <param name="createdAt">Дата создания.</param>
    /// <param name="updatedAt">Дата последнего обновления.</param>
    protected TimeAuditableEntity(DateTime createdAt, DateTime updatedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="TimeAuditableEntity{TKey}"/> с текущим временем для дат создания и обновления.
    /// </summary>
    protected TimeAuditableEntity() : this(DateTime.UtcNow, DateTime.UtcNow)
    {
        
    }

    /// <summary>
    /// Получает или задает время создания сущности.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Получает или задает время последнего обновления сущности.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}

/// <summary>
/// Представляет абстрактный класс для сущностей с типом идентификатора <see cref="Guid"/>, отслеживающих время создания и последнего обновления.
/// </summary>
public abstract class TimeAuditableEntity : TimeAuditableEntity<Guid>
{
    
}
