using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communication
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Discriminator { get; set; }

        public AuthenticationResponse(int id, string userName,string email, string token, string discriminator)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Token = token;
            Discriminator = discriminator;
        }
    }
}
