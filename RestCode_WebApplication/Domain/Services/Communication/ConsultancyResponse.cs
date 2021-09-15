using System;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class ConsultancyResponse : BaseResponse<Consultancy>
    {
        public ConsultancyResponse(Consultancy resource) : base(resource)
        {
        }

        public ConsultancyResponse(string message) : base(message)
        {
        }
    }
}
