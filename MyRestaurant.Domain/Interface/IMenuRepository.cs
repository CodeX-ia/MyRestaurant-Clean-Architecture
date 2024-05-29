using MyRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestaurant.Domain.Interface;

public interface IMenuRepository
{
    Task<Menu> GetByIdAsync(Guid id);
    Task<IEnumerable<Menu>> GetAllAsync();
    Task AddAsync(Menu menu);
    Task UpdateAsync(Menu menu);
    Task DeleteAsync(Guid id);
    Task RemoveAsync(Menu menu);
}
