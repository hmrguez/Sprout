using Domain.Common.Models;

namespace Domain.Entities;

public class User(Guid id) : Entity<Guid>(id)
{
    public User() : this(Guid.NewGuid())
    {
    }
    
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}