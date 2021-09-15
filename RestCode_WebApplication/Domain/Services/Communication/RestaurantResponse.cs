using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class RestaurantResponse : BaseResponse<Restaurant>
    {
        public RestaurantResponse(Restaurant restaurant) : base(restaurant)
        {
        }

        public RestaurantResponse(string message) : base(message)
        {

        }
    }
}
