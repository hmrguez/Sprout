using Domain.Common.Models;
using Domain.Course.ValueObjects;
using Domain.User.Entities;

namespace Domain.Course.Entities;

public class Lesson(LessonId id) : AggregateRoot<LessonId>(id)
{
    public CourseId CourseId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string VideoUrl { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public int Order { get; set; }
    public int Rating { get; set; }

    public List<Student> Students { get; set; } = null!;
}