namespace ET.BuildingBlocks.Presentation;

/// <summary>
/// Представляет результат операции без конкретного возвращаемого значения.
/// </summary>
public class Result
{
    /// <summary>
    /// Создает новый экземпляр класса <see cref="Result"/>.
    /// </summary>
    /// <param name="isSuccess">Признак успешности результата.</param>
    /// <param name="error">Ошибки, связанные с результатом.</param>
    public Result(bool isSuccess, params Error[] error)
    {
        if (isSuccess && error.Any())
            throw new InvalidOperationException();

        if (!isSuccess && !error.Any())
            throw new InvalidOperationException();

        IsSuccess = isSuccess;
        Errors = error;
    }

    /// <summary>
    /// Получает значение, указывающее, успешен ли результат.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Получает массив ошибок, связанных с результатом.
    /// </summary>
    public Error[] Errors { get; }

    public static Result Success() => new(true);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true);

    public static Result Failure(Error[] errors) => new(false, errors);

    public static Result<TValue?> Failure<TValue>(Error[] error) => new(default, false, error);
}

/// <summary>
/// Представляет результат операции с конкретным возвращаемым значением.
/// </summary>
/// <typeparam name="TValue">Тип возвращаемого значения.</typeparam>
public class Result<TValue> : Result
{
    /// <summary>
    /// Создает новый экземпляр класса <see cref="Result{TValue}"/>.
    /// </summary>
    /// <param name="value">Возвращаемое значение.</param>
    /// <param name="isSuccess">Признак успешности результата.</param>
    /// <param name="errors">Ошибки, связанные с результатом.</param>
    public Result(TValue value, bool isSuccess, params Error[] errors) : base(isSuccess, errors) => _value = value;

    private readonly TValue? _value;

    /// <summary>
    /// Получает возвращаемое значение результата.
    /// </summary>
    public TValue? Value => IsSuccess ? _value! : default;

    public static implicit operator Result<TValue?>(TValue? value) => Success(value);
}