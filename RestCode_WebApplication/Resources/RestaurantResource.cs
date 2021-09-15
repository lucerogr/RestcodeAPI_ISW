using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class RestaurantResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CellPhoneNumber { get; set; }
        public int OwnerId { get; set; }

    }
}
