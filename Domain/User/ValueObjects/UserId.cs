using Domain.Common.Models;

namespace Domain.User.ValueObjects;

public class UserId(Guid id) : ValueObject
{
    public Guid Value { get; private set; } = id;

    public static UserId New() => new(Guid.NewGuid());

    public UserId(): this(Guid.NewGuid())
    {
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        return [Value];
    }
}