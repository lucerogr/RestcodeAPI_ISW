using System;
using System.ComponentModel.DataAnnotations;

namespace RestCode_WebApplication.Resources
{
    public class SaveConsultancyResource
    {
        [Required]
        public string Diagnosis { get; set; }

        [Required]
        public string Recommendation { get; set; }

        [Required]
        public int AppointmentId { get; set; }

    }
}
