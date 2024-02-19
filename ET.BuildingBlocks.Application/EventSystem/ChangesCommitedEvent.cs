using ET.BuildingBlocks.Domain.DomainEvents;

namespace ET.BuildingBlocks.Application.EventSystem;

public record ChangesCommittedEvent : DomainEvent
{
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="ChangesCommittedEvent"/>.
    /// </summary>
    /// <param name="isSuccess">Успешно ли было подтверждение.</param>
    /// <param name="errorMessage">Сообщение об ошибке (если есть).</param>
    public ChangesCommittedEvent(bool isSuccess, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        CommittedAt = DateTime.UtcNow;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    /// Время, когда были подтверждены изменения.
    /// </summary>
    public DateTime CommittedAt { get; set; }

    /// <summary>
    /// Указывает, было ли подтверждение успешным.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Сообщение об ошибке, если таковая имеется.
    /// </summary>
    public string? ErrorMessage { get; set; }

    /// <summary>
    /// Создает экземпляр события с успешным подтверждением.
    /// </summary>
    /// <returns>Экземпляр события.</returns>
    public static ChangesCommittedEvent Success()
    {
        return new ChangesCommittedEvent(true);
    }
    
    /// <summary>
    /// Создает экземпляр события с неудачным подтверждением.
    /// </summary>
    /// <param name="errorMessage">Сообщение об ошибке.</param>
    /// <returns>Экземпляр события.</returns>
    public static ChangesCommittedEvent Failure(string? errorMessage = null)
    {
        return new ChangesCommittedEvent(false, errorMessage);
    }
}