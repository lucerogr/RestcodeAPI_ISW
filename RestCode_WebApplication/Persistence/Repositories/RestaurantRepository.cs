using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Persistence.Repositories
{
    public class RestaurantRepository : BaseRepository, IRestaurantRepository
    {
        public RestaurantRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Restaurant>> ListAsync()
        {

            return await _context.Restaurants.ToListAsync();
        }

        public async Task AddAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
        }

        public async Task<Restaurant> FindById(int id)
        {
            return await _context.Restaurants.FindAsync(id);
        }

        public void Update(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
        }

        public void Remove(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
        }
    }
}
