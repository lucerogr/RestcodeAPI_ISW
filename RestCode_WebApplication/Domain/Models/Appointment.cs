using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public DateTime ScheduleDateTime { get; set; }
        public String Topic { get; set; }
        public String MeetLink { get; set; }
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        //Relation One to One with Consultancy
        public Consultancy Consultancy { get; set; }


    }
}
