using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class AppointmentResource
    {
        public int Id { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public String Topic { get; set; }
        public String MeetLink { get; set; }
        public int OwnerId { get; set; }
        public int ConsultantId { get; set; }
    }
}
