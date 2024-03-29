using Application.Common.Interfaces.Persistence;
using Domain;
using Domain.User;

namespace Infrastructure.Persistence.Repository;

public class UserRepository(): IUserRepository
{
    public List<User> Users { get; set; } = new List<User>();
    
    public User? GetUserByEmail(string email)
    {
        return Users.FirstOrDefault(x => x.Email == email);
    }

    public User? GetUserByUsername(string username)
    {
        return Users.FirstOrDefault(x => x.Username == username);
    }

    public void Add(User user)
    {
        Users.Add(user);
    }
}