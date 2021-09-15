using System;
using System.ComponentModel.DataAnnotations;

namespace RestCode_WebApplication.Resources
{
    public class SaveAssignmentResource
    {
        [Required]
        public bool State { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public int ConsultantId { get; set; }
    }
}
