namespace ET.BuildingBlocks.Error.Exceptions.Business;

/// <summary>
/// Представляет исключение, связанное с ошибками бизнес-логики в приложении.
/// Этот класс наследуется от класса AppException и расширяет его функциональность, 
/// добавляя контекст специфичный для ошибок бизнес-логики.
/// </summary>
public class BusinessException : AppException
{
    /// <summary>
    /// Инициализирует новый экземпляр класса BusinessException с указанным кодом ошибки и сообщением.
    /// </summary>
    /// <param name="code">Код ошибки, идентифицирующий тип бизнес-исключения.</param>
    /// <param name="message">Сообщение об ошибке, описывающее проблему.</param>
    public BusinessException(string code, string message) : base(code, message)
    {
    }
}