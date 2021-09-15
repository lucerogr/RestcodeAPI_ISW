using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaveCommentResource
    {
        [Required]
        public DateTime PublishedDate { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int PublicationId { get; set; }

        public int ConsultantId { get; set; }

        public int OwnerId { get; set; }
    }
}
