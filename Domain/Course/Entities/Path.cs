using Domain.Common.Models;
using Domain.Course.ValueObjects;
using Domain.User.Entities;
using Domain.User.ValueObjects;

namespace Domain.Course.Entities;

public class Path(PathId id) : AggregateRoot<PathId>(id)
{
    public CreatorId CreatorId { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ThumbnailUrl { get; set; } = null!;
    public int Rating { get; set; }

    public List<Course> Courses { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;
}