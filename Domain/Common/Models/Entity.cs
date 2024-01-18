namespace Domain.Common.Models;

public abstract class Entity<TId>(TId id): IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; } = id;

    bool IEquatable<Entity<TId>>.Equals(Entity<TId>? other)
    {
        return Equals(other);
    }

    public override bool Equals(object? obj) 
        => obj is Entity<TId> entity && Id.Equals(entity.Id);

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) => left.Equals(right);
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        if (left is null || right is null)
            return false;
        
        return !left.Equals(right);
    }
}