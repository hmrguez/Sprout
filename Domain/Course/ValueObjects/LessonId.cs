using Domain.Common.Models;

namespace Domain.Course.ValueObjects;

public class LessonId(Guid id): ValueObject
{
    public Guid Value { get; set; } = id;
    
    public static LessonId New() => new(Guid.NewGuid());

    public LessonId(): this(Guid.NewGuid())
    {
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}