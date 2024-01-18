namespace Domain.Common.Models;

public abstract class ValueObject: IEquatable<ValueObject>
{
    protected abstract IEnumerable<object?> GetEqualityComponents();

    bool IEquatable<ValueObject>.Equals(ValueObject? other)
    {
        return Equals(other);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType())
            return false;

        var valueObject = (ValueObject)obj;

        return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }

    public static bool operator ==(ValueObject left, ValueObject right)
        => Equals(left, right);
    
    public static bool operator !=(ValueObject left, ValueObject right)
        => !Equals(left, right);

    public override int GetHashCode()
    {
        return GetEqualityComponents().Select(x => x?.GetHashCode() ?? 0).Aggregate((x, y) => x ^ y);
    }
}