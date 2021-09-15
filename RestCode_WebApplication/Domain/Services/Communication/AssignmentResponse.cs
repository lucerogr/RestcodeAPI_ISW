using System;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class AssignmentResponse : BaseResponse<Assignment>
    {
        public AssignmentResponse(Assignment resource) : base(resource)
        {
        }

        public AssignmentResponse(string message) : base(message)
        {
        }
    }
}
