using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;
using RestCode_WebApplication.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IConsultantRepository _consultantRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IConsultantRepository consultantRepository, IOwnerRepository ownerRepository, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _consultantRepository = consultantRepository;
            _ownerRepository = ownerRepository;
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest request)
        {
            Consultant cuser = null;
            Owner ouser = null;

            cuser = await _consultantRepository.FindByMail(request.Email);
            if(cuser != null)
            {
                if (cuser.Password != request.Password)
                    return null;

                var token = GenerateJwtToken(request.Password);
                return new AuthenticationResponse(cuser.Id,cuser.UserName, cuser.Email, token, "consultant");
            }
            else
            {
                ouser = await _ownerRepository.FindByMail(request.Email);
                if (ouser == null)
                    return null;

                if (ouser.Password != request.Password)
                    return null;

                var token = GenerateJwtToken(request.Password);
                return new AuthenticationResponse(ouser.Id, ouser.UserName, ouser.Email, token, "owner");
            }

            
        }

        private string GenerateJwtToken(string user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
