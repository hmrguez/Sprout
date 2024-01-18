using Domain.Common.Models;

namespace Domain.User.ValueObjects;

public class StudentId(Guid id): ValueObject
{
    public Guid Value { get; set; } = id;
    
    public static StudentId New() => new(Guid.NewGuid());

    public StudentId(): this(Guid.NewGuid())
    {
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}