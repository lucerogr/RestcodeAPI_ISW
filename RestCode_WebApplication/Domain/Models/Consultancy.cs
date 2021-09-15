using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Consultancy
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        
        
    }
}
