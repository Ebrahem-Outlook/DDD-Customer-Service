namespace Customer_Service.Domain.Core.BaseType;

/// <summary>
/// Defines the contract for an entity with an identifier.
/// </summary>
/// <typeparam name="TId">The type of the identifier.</typeparam>
public interface IEntity<TId>
{
    /// <summary>
    /// Gets the identifier of the entity.
    /// </summary>
    TId Id { get; }
}