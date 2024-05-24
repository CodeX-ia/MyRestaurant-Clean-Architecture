using MyRestaurant.Domain.Interface;

namespace MyRestaurant.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMenuRepository Menus { get; }
    Task CommitAsync();
}
