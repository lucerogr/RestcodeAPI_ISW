using System;
using System.ComponentModel.DataAnnotations;

namespace RestCode_WebApplication.Resources
{
    public class SaveAppointmentResource
    {
        [Required]
        public DateTime CurrentDateTime { get; set; }

        [Required]
        public DateTime ScheduleDateTime { get; set; }

        [Required]
        public String Topic { get; set; }

        [Required]
        public String MeetLink { get; set; }

        [Required]
        public int OwnerId { get; set; }

        [Required]
        public int ConsultantId { get; set; }
    }
}
