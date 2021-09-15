using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> ListAsync();
        Task<RestaurantResponse> GetByIdAsync(int id);
        Task<RestaurantResponse> SaveAsync(Restaurant restaurant);
        Task<RestaurantResponse> UpdateAsync(int id, Restaurant restaurant);
        Task<RestaurantResponse> DeleteAsync(int id);
    }
}
