using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class OwnerResponse : BaseResponse<Owner>
    {
        public OwnerResponse(string message) : base(message) { }
        public OwnerResponse(Owner owner) : base(owner) { }

    }
}
