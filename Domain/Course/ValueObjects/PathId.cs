using Domain.Common.Models;

namespace Domain.Course.ValueObjects;

public class PathId(Guid id): ValueObject
{
    public Guid Value { get; set; } = id;
    
    public static PathId New() => new(Guid.NewGuid());

    public PathId(): this(Guid.NewGuid())
    {
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}