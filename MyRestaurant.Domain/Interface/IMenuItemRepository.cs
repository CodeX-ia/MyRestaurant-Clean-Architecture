using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Domain.Interface;

public interface IMenuItemRepository
{
    Task<MenuItem> GetByIdAsync(Guid id);
    Task<IEnumerable<MenuItem>> GetAllAsync();
    Task AddAsync(MenuItem menuItem);
    Task UpdateAsync(MenuItem menuItem);
    //Task DeleteAsync(Guid id);
    Task DeleteAsync(MenuItem menuItem);
}