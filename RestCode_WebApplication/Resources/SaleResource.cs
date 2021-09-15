using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaleResource
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string ClientFullName { get; set; }
        public int RestaurantId { get; set; }
    }
}
