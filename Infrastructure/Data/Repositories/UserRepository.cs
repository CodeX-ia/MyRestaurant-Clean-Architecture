using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MyRestaurantDbContext _context;

    public UserRepository(MyRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
}
