using ET.BuildingBlocks.Error.Exceptions.Business;

namespace ET.BuildingBlocks.Error.Exceptions.Validation;

/// <summary>
/// Представляет исключение, связанное с ошибками валидации данных.
/// Этот класс наследуется от BusinessException и предоставляет дополнительную информацию о свойстве, 
/// в котором произошла ошибка валидации.
/// </summary>
public class ValidationException : BusinessException
{
    /// <summary>
    /// Получает имя свойства, в котором произошла ошибка валидации.
    /// </summary>
    public string PropertyName { get; }
        
    /// <summary>
    /// Инициализирует новый экземпляр класса ValidationException с указанием свойства, кода ошибки и сообщения.
    /// </summary>
    /// <param name="propertyName">Имя свойства, в котором произошла ошибка валидации.</param>
    /// <param name="code">Код ошибки, идентифицирующий тип исключения валидации.</param>
    /// <param name="message">Сообщение об ошибке, описывающее проблему валидации.</param>
    public ValidationException(string propertyName, string code, string message) : base(code, message)
    {
        PropertyName = propertyName;
        SetTag(nameof(PropertyName), propertyName);
    }
}