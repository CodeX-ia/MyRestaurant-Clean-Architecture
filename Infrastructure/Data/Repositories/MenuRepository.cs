using Microsoft.EntityFrameworkCore;
using MyRestaurant.Application.Interfaces;
using MyRestaurant.Domain.Entities;
using MyRestaurant.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Infrastructure.Data.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly MyRestaurantDbContext _context;

    public MenuRepository(MyRestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<Menu> GetByIdAsync(Guid id)
    {
        return await _context.Menus.Include(m => m.Items).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        return await _context.Menus.Include(m => m.Items).ToListAsync();
    }

    public async Task AddAsync(Menu menu)
    {
        await _context.Menus.AddAsync(menu);
    }

    public async Task UpdateAsync(Menu menu)
    {
        _context.Menus.Update(menu);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var menu = await GetByIdAsync(id);
        if (menu != null)
        {
            _context.Menus.Remove(menu);
            await Task.CompletedTask;
        }
    }

    public async Task RemoveAsync(Menu menu)
    {
        _context.Menus.Remove(menu);
        await Task.CompletedTask;
    }
}