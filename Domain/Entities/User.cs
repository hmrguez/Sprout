namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; } = new();
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Email { get; set; } = null!;
}