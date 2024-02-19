namespace ET.BuildingBlocks.Domain;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    public TId Id { get; init; }
    
    protected Entity() : this(default)
    {
    }

    protected Entity(TId id)
    {
        Id = id;
    }
    
    public static bool operator ==(Entity<TId>? obj1, Entity<TId>? obj2)
    {
        return obj1?.Equals(obj2) ?? Equals(obj2, null);
    }

    public static bool operator !=(Entity<TId>? obj1, Entity<TId>? obj2)
    {
        return !(obj1 == obj2);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Entity<TId>)obj);
    }

    public override int GetHashCode()
    {
        return EqualityComparer<TId>.Default.GetHashCode(Id);
    }
}

public abstract class Entity : Entity<Guid>
{
    // Так как этот класс является расширением Entity<TId> с предустановленным типом идентификатора Guid,
    // специфические методы или свойства в этом классе отсутствуют.
}