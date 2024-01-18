using Domain.Common.Models;

namespace Domain.User.ValueObjects;

public class CreatorId(Guid id) : ValueObject
{
    public Guid Value { get; set; } = id;

    public static CreatorId New() => new CreatorId(Guid.NewGuid());

    public CreatorId(): this(Guid.NewGuid())
    {
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}