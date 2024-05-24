using MyRestaurant.Application.Interfaces;
using MyRestaurant.Domain.Interface;
using MyRestaurant.Infrastructure.Data;
using MyRestaurant.Infrastructure.Data.Repositories;

namespace MyRestaurant.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyRestaurantDbContext _context;
    private IMenuRepository _menuRepository;

    public UnitOfWork(MyRestaurantDbContext context)
    {
        _context = context;
    }

    public IMenuRepository Menus
    {
        get
        {
            return _menuRepository ??= new MenuRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}