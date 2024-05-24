using MyRestaurant.Domain.Entities;

namespace MyRestaurant.Domain.Interface;

public interface IUserRepository
{
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}
