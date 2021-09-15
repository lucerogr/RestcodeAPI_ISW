using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class PublicationResource
    {
        public int Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int ConsultantId { get; set; }
    }
}
