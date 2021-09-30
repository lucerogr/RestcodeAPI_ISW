using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public abstract class Profile
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Cellphone { get; set; }
        public virtual string Email { get; set; }
        [JsonIgnore]
        public virtual string Password { get; set; }
        [JsonIgnore]
        public virtual string Token { get; set; }
        
    }
}
