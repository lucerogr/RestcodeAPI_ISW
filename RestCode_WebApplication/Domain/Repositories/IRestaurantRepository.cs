using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> ListAsync();
        Task AddAsync(Restaurant restaurant);
        Task<Restaurant> FindById(int id);
        void Update(Restaurant restaurant);
        void Remove(Restaurant restaurant);
    }
}
