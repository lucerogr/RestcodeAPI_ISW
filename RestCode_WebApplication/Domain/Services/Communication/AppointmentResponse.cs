using System;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class AppointmentResponse : BaseResponse<Appointment>
    {
        public AppointmentResponse(Appointment resource) : base(resource)
        {
        }

        public AppointmentResponse(string message) : base(message)
        {
        }
    }
}
