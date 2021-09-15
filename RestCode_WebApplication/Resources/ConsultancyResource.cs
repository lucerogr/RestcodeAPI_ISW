using System;
namespace RestCode_WebApplication.Resources
{
    public class ConsultancyResource
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Recommendation { get; set; }

        public int AppointmentId { get; set; }
    }
}
