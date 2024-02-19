namespace ET.BuildingBlocks.Domain;

public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Получает компоненты объекта значения, используемые для проверки равенства.
    /// </summary>
    /// <returns>Коллекция компонентов для проверки равенства.</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    #region Equality

    /// <summary>
    /// Оператор равенства для сравнения двух объектов значения.
    /// </summary>
    public static bool operator ==(ValueObject obj1, ValueObject obj2)
    {
        return obj1?.Equals(obj2) ?? Equals(obj2, null);
    }

    /// <summary>
    /// Оператор неравенства для сравнения двух объектов значения.
    /// </summary>
    public static bool operator !=(ValueObject obj1, ValueObject obj2)
    {
        return !(obj1 == obj2);
    }

    /// <summary>
    /// Проверяет равенство текущего объекта значения с указанным объектом значения.
    /// </summary>
    public bool Equals(ValueObject? obj)
    {
        return Equals(obj as object);
    }

    /// <summary>
    /// Проверяет равенство текущего объекта значения с указанным объектом.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;
        
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Возвращает хеш-код для текущего объекта значения.
    /// </summary>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x != null ? x.GetHashCode() : 0)
            .Aggregate((x, y) => x ^ y);
    }

    #endregion
}