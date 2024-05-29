using Microsoft.EntityFrameworkCore;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Infrastructure.Data.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly MyRestaurantDbContext _context;

    public MenuItemRepository(MyRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<MenuItem> GetByIdAsync(Guid id)
    {
        return await _context.MenuItems.FindAsync(id);
    }

    public async Task<IEnumerable<MenuItem>> GetAllAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task AddAsync(MenuItem menuItem)
    {
        await _context.MenuItems.AddAsync(menuItem);
    }

    public async Task UpdateAsync(MenuItem menuItem)
    {
        _context.MenuItems.Update(menuItem);
    }

    public async Task DeleteAsync(MenuItem menuItem)
    {
        _context.MenuItems.Remove(menuItem);
    }
}