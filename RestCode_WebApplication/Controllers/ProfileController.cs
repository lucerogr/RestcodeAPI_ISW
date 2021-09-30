using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestCode_WebApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [AllowAnonymous]
        [SwaggerOperation(
            Summary = "Authenticate User",
            Description = "Authenticate User",
            OperationId = "AuthenticateUser",
            Tags = new[] { "users" }
            )]
        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticationRequest request)
        {
            var response = await _profileService.Authenticate(request);
            if (response == null)
                return BadRequest(new { message = "Invalid Mail or Password" });

            return Ok(response);
        }
    }
}
