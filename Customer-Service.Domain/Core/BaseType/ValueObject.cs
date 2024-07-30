namespace Customer_Service.Domain.Core.BaseType;

/// <summary>
/// Represents a base class for value objects.
/// Value objects are compared based on their values rather than their references.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// Gets the components of the value object used for equality comparison.
    /// Derived classes must override this method to provide the components that define equality.
    /// </summary>
    /// <returns>An enumerable collection of components that are used for equality comparison.</returns>
    protected abstract IEnumerable<object> GetEqualityComponents();

    /// <summary>
    /// Determines whether the current object is equal to another object.
    /// </summary>
    /// <param name="obj">The object to compare with the current object.</param>
    /// <returns>true if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
            return false;

        return Equals((ValueObject)obj);
    }

    /// <summary>
    /// Determines whether the current value object is equal to another value object.
    /// </summary>
    /// <param name="other">The value object to compare with the current value object.</param>
    /// <returns>true if the value objects are equal; otherwise, false.</returns>
    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// Serves as the hash function for the value object.
    /// </summary>
    /// <returns>A hash code for the current value object.</returns>
    public override int GetHashCode()
    {
        // Use a prime number (31) for hash code calculation.
        return GetEqualityComponents()
            .Aggregate(17, (current, obj) => current * 31 + (obj?.GetHashCode() ?? 0));
    }

    /// <summary>
    /// Returns a string that represents the current value object.
    /// </summary>
    /// <returns>A string representation of the value object.</returns>
    public override string ToString()
    {
        return string.Join(", ", GetEqualityComponents());
    }

    /// <summary>
    /// Determines whether two value objects are equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>true if the value objects are equal; otherwise, false.</returns>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        // Use reference equality for the same instance or null checks.
        if (ReferenceEquals(left, right))
            return true;

        // Use the Equals method for comparison.
        return left?.Equals(right) ?? false;
    }

    /// <summary>
    /// Determines whether two value objects are not equal.
    /// </summary>
    /// <param name="left">The first value object to compare.</param>
    /// <param name="right">The second value object to compare.</param>
    /// <returns>true if the value objects are not equal; otherwise, false.</returns>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !(left == right);
    }
}
