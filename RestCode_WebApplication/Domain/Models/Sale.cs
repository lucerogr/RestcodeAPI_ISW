using RestCode_WebApplication.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string ClientFullName { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        public IList<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}