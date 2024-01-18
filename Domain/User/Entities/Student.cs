using Domain.Common.Models;
using Domain.Course.Entities;
using Domain.User.ValueObjects;

namespace Domain.User.Entities;

public class Student(StudentId id) : AggregateRoot<StudentId>(id)
{
    public UserId UserId { get; set; } = null!;

    public List<Lesson> Lessons { get; set; } = null!;
}