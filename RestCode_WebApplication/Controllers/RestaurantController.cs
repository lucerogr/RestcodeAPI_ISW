using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Extensions;
using RestCode_WebApplication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<RestaurantResource>> GetAllAsync()
        {
            var restaurants = await _restaurantService.ListAsync();
            var resources = _mapper
                .Map<IEnumerable<Restaurant>, IEnumerable<RestaurantResource>>(restaurants);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _restaurantService.GetByIdAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);
            var restaurantResource = _mapper.Map<Restaurant, RestaurantResource>(result.Resource);
            return Ok(restaurantResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveRestaurantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var restaurant = _mapper.Map<SaveRestaurantResource, Restaurant>(resource);
            var result = await _restaurantService.SaveAsync(restaurant);

            if (!result.Success)
                return BadRequest(result.Message);

            var restaurantResource = _mapper.Map<Restaurant, RestaurantResource>(result.Resource);
            return Ok(restaurantResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveRestaurantResource resource)
        {
            var restaurant = _mapper.Map<SaveRestaurantResource, Restaurant>(resource);
            var result = await _restaurantService.UpdateAsync(id, restaurant);

            if (!result.Success)
                return BadRequest(result.Message);
            var restaurantResource = _mapper.Map<Restaurant, RestaurantResource>(result.Resource);
            return Ok(restaurantResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _restaurantService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);
            var restaurantResource = _mapper.Map<Restaurant, RestaurantResource>(result.Resource);
            return Ok(restaurantResource);
        }
    }
}
