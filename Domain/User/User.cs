using Domain.Common.Models;
using Domain.User.ValueObjects;

namespace Domain.User;

public class User(UserId id) : AggregateRoot<UserId>(id)
{
    public DateTime ProfileCreatedDate { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;

    public StudentId? StudentId { get; set; }
    public CreatorId? CreatorId { get; set; }
}