using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestCode_WebApplication.Resources
{
    public class SaveSaleResource
    {
        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClientFullName { get; set; }

        [Required]
        public int RestaurantId { get; set; }

    }
}
