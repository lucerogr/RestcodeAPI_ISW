using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public int PublicationId { get; set; }
        public Publication Publication { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public int ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
    }
}
