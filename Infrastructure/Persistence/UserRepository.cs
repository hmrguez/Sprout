using Application.Common.Interfaces.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence;

public class UserRepository(): IUserRepository
{
    public User? GetUserByEmail(string email)
    {
        // throw new Exception("This is a nd wqewer");
        
        return new()
        {

        };
        // return context.Users.SingleOrDefault(user => user.Email == email);
    }

    public User? GetUserByUsername(string username)
    {
        return new User();
        // return context.Users.SingleOrDefault(user => user.Email == username);
    }

    public void Add(User user)
    {
        // context.Users.Add(user);
        // context.SaveChanges();
    }
}