namespace ET.BuildingBlocks.Domain;

public abstract class AuditableEntity<TKey> : Entity<TKey>, ITimeAuditable, IActorAuditable
{
    /// <summary>
    /// Получает или задает дату и время создания сущности.
    /// </summary>
    public DateTime CreatedAt { get; set; }
        
    /// <summary>
    /// Получает или задает дату и время последнего обновления сущности.
    /// </summary>
    public DateTime UpdatedAt { get; set; }
        
    /// <summary>
    /// Получает или задает идентификатор пользователя, который создал сущность.
    /// </summary>
    public Guid CreatedBy { get; set; }
        
    /// <summary>
    /// Получает или задает идентификатор пользователя, который последний раз обновил сущность.
    /// </summary>
    public Guid UpdatedBy { get; set; }
}

/// <summary>
/// Представляет абстрактный аудитируемый объект (сущность) с типом идентификатора Guid.
/// Это упрощенная версия AuditableEntity с предустановленным типом идентификатора Guid.
/// </summary>
public abstract class AuditableEntity : AuditableEntity<Guid>
{
    // Так как этот класс является расширением AuditableEntity<TKey> с предустановленным типом идентификатора Guid,
    // специфические методы или свойства в этом классе отсутствуют.
}