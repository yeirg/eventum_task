namespace ET.BuildingBlocks.Presentation;

public class Error : IEquatable<Error>
{
    /// <summary>
    /// Ошибка, которая означает отсутствие ошибки.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty, new());

    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="Error"/> с указанными значениями.
    /// </summary>
    /// <param name="code">Код ошибки.</param>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="tags">Дополнительные метки, связанные с ошибкой.</param>
    /// <param name="property">Пользовательское свойство вызвавший ошибку.</param>
    public Error(string code, string message, Dictionary<string, string>? tags = null, string? property = null)
    {
        Code = code;
        Message = message;
        Tags = tags ?? new Dictionary<string, string>();
        Property = property;
    }
    
    /// <summary>
    /// Получает код ошибки.
    /// </summary>
    public string Code { get; }
    
    /// <summary>
    /// Получает сообщение об ошибке.
    /// </summary>
    public string Message { get; }
    
    /// <summary>
    /// Получает или задает метки, связанные с ошибкой.
    /// </summary>
    public Dictionary<string, string> Tags { get; set; }

    /// <summary>
    /// Пользовательское свойство вызвавший ошибку.
    /// </summary>
    public string? Property { get; set; }
    
    public static implicit operator string(Error error) => error.Code;

    public bool Equals(Error? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Error)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    public static bool operator ==(Error error, Error error2)
    {
        return error.Equals(error2);
    }

    public static bool operator !=(Error error, Error error2)
    {
        return !(error == error2);
    }
}