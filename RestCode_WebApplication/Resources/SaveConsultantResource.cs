using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace RestCode_WebApplication.Resources
{
    public class SaveConsultantResource
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Cellphone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
       
        [Required]
        public string LinkedinLink { get; set; }

    }
}
