using MyRestaurant.Domain.ValueObjects;

namespace MyRestaurant.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public Email Email { get; set; }
    public string PasswordHash { get; set; }

    private User() { }

    public User(string username, Email email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
    }
}
