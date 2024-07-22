namespace Customer_Service.Domain.Core.BaseType;

public abstract class Entity<TId> : IEquatable<Entity<TId>?>
{
    protected Entity(TId id) => Id = id;

    protected Entity() { }

    public TId Id { get; } = default!;

    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    public bool Equals(Entity<TId>? other)
    {
        return other is not null &&
               EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualityComparer<Entity<TId>>.Default.Equals(left, right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
 