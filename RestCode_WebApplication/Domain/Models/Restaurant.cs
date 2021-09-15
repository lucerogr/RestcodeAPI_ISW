using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CellPhoneNumber { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int RestaurantId { get; set; }

        public IList<Category>Categories{ get; set; } = new List<Category>();
        public IList<Assignment> Assignments { get; set; } = new List<Assignment>();
        public IList<Sale> Sales { get; set; } = new List<Sale>();
    }
}
