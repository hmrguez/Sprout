using Application.Common.Interfaces.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class UserRepository(AppDbContext context): IUserRepository
{
    public User? GetUserByEmail(string email)
    {
        return context.Users.SingleOrDefault(user => user.Email == email);
    }

    public User? GetUserByUsername(string username)
    {
        return context.Users.SingleOrDefault(user => user.Email == username);
    }

    public void Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }
}