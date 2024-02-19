namespace ET.BuildingBlocks.Domain;

public abstract class AuditableAggregateRoot<TId> : AggregateRoot<TId>, ITimeAuditable
{
    /// <summary>
    /// Получает или задает дату и время создания агрегата.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Получает или задает дату и время последнего обновления агрегата.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// Получает или задает идентификатор пользователя, который создал агрегат.
    /// </summary>
    public Guid CreatedBy { get; set; }
    
    /// <summary>
    /// Получает или задает идентификатор пользователя, который последний раз обновил агрегат.
    /// </summary>
    public Guid UpdatedBy { get; set; }
}

/// <summary>
/// Представляет абстрактный корневой элемент агрегата с аудитом и типом идентификатора Guid.
/// Это упрощенная версия AuditableAggregateRoot с предустановленным типом идентификатора Guid.
/// </summary>
public abstract class AuditableAggregateRoot : AuditableAggregateRoot<Guid>
{
    // Так как этот класс является расширением AuditableAggregateRoot<TId> с предустановленным типом идентификатора Guid,
    // специфические методы или свойства в этом классе отсутствуют.
}
