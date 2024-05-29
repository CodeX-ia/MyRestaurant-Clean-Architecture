using MyRestaurant.Application.Interfaces;
using MyRestaurant.Domain.Interface;
using MyRestaurant.Infrastructure.Data;
using MyRestaurant.Infrastructure.Data.Repositories;

namespace MyRestaurant.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyRestaurantDbContext _context;
    private IMenuRepository _menuRepository;
    private IMenuItemRepository _menuItemRepository;

    public UnitOfWork(MyRestaurantDbContext context)
    {
        _context = context;
    }

    public IMenuRepository Menus => _menuRepository ??= new MenuRepository(_context);
    public IMenuItemRepository MenuItemRepository => _menuItemRepository ??= new MenuItemRepository(_context);

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}