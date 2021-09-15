using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class PublicationResponse : BaseResponse<Publication>
    {
        public PublicationResponse(Publication resource) : base(resource) { }

        public PublicationResponse(string message) : base(message) { }
    }
}
