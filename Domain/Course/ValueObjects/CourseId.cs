using Domain.Common.Models;

namespace Domain.Course.ValueObjects;

public class CourseId(Guid id) : ValueObject
{

    public CourseId(): this(Guid.NewGuid())
    {
    }
    
    public Guid Value { get; set; } = id;
    
    public static CourseId New() => new(Guid.NewGuid());
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}