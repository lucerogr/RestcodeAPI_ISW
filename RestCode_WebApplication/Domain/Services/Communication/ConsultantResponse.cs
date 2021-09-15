using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class ConsultantResponse : BaseResponse<Consultant>
    {
        public ConsultantResponse(Consultant resource) : base(resource) {}

        public ConsultantResponse(string message) : base(message) {}
    }
}