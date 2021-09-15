using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<IEnumerable<Category>> ListByRestaurantIdAsync(int restaurantId);
        Task AddAsync(Category category);
        Task<Category> FindById(int id);
        void Update(Category category);
        void Remove(Category category);
    }
}
