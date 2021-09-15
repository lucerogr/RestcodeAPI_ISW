using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class CategoryResource
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int RestaurantId { get; set; }
    }
}
