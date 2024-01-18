using Domain.Common.Models;
using Domain.User.ValueObjects;
using Domain.Course;

namespace Domain.User.Entities;

public class Creator(CreatorId id) : AggregateRoot<CreatorId>(id)
{
    public UserId UserId { get; set; } = null!;
    public List<Course.Course> Courses { get; set; } = null!;
}