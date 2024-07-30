namespace Customer_Service.Domain.Core.BaseType;

/// <summary>
/// Represents a base class for entities with an identifier.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>?>, IEntity<TId>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class with the specified identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    protected Entity(TId id) => Id = id;

    /// <summary>
    /// Required by EFCore.
    /// </summary>
    protected Entity() { }

    /// <summary>
    /// Gets the identifier of the entity.
    /// </summary>
    public TId Id { get; } = default!;

    /// <summary>
    /// Checks if the current object is equal to another <see cref="Entity{TId}"/>.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>true if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Entity<TId>);
    }

    /// <summary>
    /// Checks if the current entity is equal to another <see cref="Entity{TId}"/>.
    /// </summary>
    /// <param name="other">The other entity to compare.</param>
    /// <returns>true if the entities are equal; otherwise, false.</returns>
    public bool Equals(Entity<TId>? other)
    {
        return other is not null &&
               EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    /// <summary>
    /// Gets the hash code for the entity based on its identifier.
    /// </summary>
    /// <returns>The hash code of the entity.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    /// <summary>
    /// Determines whether two <see cref="Entity{TId}"/> objects are equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>true if the entities are equal; otherwise, false.</returns>
    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return EqualityComparer<Entity<TId>>.Default.Equals(left, right);
    }

    /// <summary>
    /// Determines whether two <see cref="Entity{TId}"/> objects are not equal.
    /// </summary>
    /// <param name="left">The first entity to compare.</param>
    /// <param name="right">The second entity to compare.</param>
    /// <returns>true if the entities are not equal; otherwise, false.</returns>
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
}
