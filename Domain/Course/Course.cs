using Domain.Common.Models;
using Domain.Course.Entities;
using Domain.Course.ValueObjects;
using Domain.User.Entities;
using Domain.User.ValueObjects;
using Path = Domain.Course.Entities.Path;

namespace Domain.Course;

public class Course(CourseId id) : AggregateRoot<CourseId>(id)
{
    public CreatorId CreatorId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public int Rating { get; set; }

    public List<Path> Paths { get; set; } = null!;
    public List<Lesson> Lessons { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;

    public Course(): this(new CourseId())
    {
    }
}