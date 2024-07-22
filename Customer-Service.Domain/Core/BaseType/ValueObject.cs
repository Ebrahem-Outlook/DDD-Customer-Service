namespace Customer_Service.Domain.Core.BaseType;

public abstract class ValueObject : IEquatable<ValueObject>
{
    // Abstract method to get equality components
    protected abstract IEnumerable<object> GetEqualityComponents();

    // Equals method overridden for value-based comparison
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        return Equals((ValueObject)obj);
    }

    // IEquatable implementation for value-based comparison
    public bool Equals(ValueObject other)
    {
        if (other == null)
            return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    // HashCode calculation based on equality components
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) => current * 31 + (obj?.GetHashCode() ?? 0));
    }

    // ToString method to provide a string representation of the object
    public override string ToString()
    {
        return string.Join(", ", GetEqualityComponents());
    }

    // Equality operators
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        if (ReferenceEquals(left, right))
            return true;

        if (left is null || right is null)
            return false;

        return left.Equals(right);
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !(left == right);
    }
}
