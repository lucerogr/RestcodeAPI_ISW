using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IProfileService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
}
