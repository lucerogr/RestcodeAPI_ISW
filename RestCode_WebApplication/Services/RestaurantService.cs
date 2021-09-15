using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public readonly IUnitOfWork _unitOfWork;

        public RestaurantService(IRestaurantRepository restaurantRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _unitOfWork = unitOfWork;   
        }

        public async Task<IEnumerable<Restaurant>> ListAsync()
        {
            return await _restaurantRepository.ListAsync();
        }

        public async Task<RestaurantResponse> GetByIdAsync(int id)
        {
            var existingRestaurant = await _restaurantRepository.FindById(id);

            if (existingRestaurant == null)
                return new RestaurantResponse("Restaurant not found");
            return new RestaurantResponse(existingRestaurant);
        }

        public async Task<RestaurantResponse> SaveAsync(Restaurant Restaurant)
        {
            try
            {
                await _restaurantRepository.AddAsync(Restaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(Restaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"An error ocurred while saving the Restaurant: {ex.Message}");
            }
        }

        public async Task<RestaurantResponse> UpdateAsync(int id, Restaurant restaurant)
        {
            var existingRestaurant = await _restaurantRepository.FindById(id);

            if (existingRestaurant == null)
                return new RestaurantResponse("Restaurant not found");

            existingRestaurant.Name = restaurant.Name;
            existingRestaurant.Address = restaurant.Address;
            existingRestaurant.CellPhoneNumber = restaurant.CellPhoneNumber;

            try
            {
                _restaurantRepository.Update(existingRestaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(existingRestaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"An error ocurred while updating Restaurant: {ex.Message}");
            }

        }

        public async Task<RestaurantResponse> DeleteAsync(int id)
        {
            var existingRestaurant = await _restaurantRepository.FindById(id);

            if (existingRestaurant == null)
                return new RestaurantResponse("Restaurant not found");

            try
            {
                _restaurantRepository.Remove(existingRestaurant);
                await _unitOfWork.CompleteAsync();

                return new RestaurantResponse(existingRestaurant);
            }
            catch (Exception ex)
            {
                return new RestaurantResponse($"An error ocurred while deleting Restaurant: {ex.Message}");
            }
        }
    }
}
