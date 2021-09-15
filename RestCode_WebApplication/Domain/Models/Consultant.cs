using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Consultant : Profile
    {
        public override int Id { get; set; }
        public override string UserName { get; set; }
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        public override string Cellphone { get; set; }
        public override string Email { get; set; }
        public override string Password { get; set; }
        public string LinkedinLink { get; set; }

        public IList<Assignment> Assignments { get; set; } = new List<Assignment>();
        public IList<Publication> Publications { get; set; } = new List<Publication>();
        public IList<Appointment> Appointments { get; set; } = new List<Appointment>();
        public IList<Comment> Comments { get; set; } = new List<Comment>();

    }
}
