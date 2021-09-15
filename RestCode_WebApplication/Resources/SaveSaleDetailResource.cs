using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Resources
{
    public class SaveSaleDetailResource
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int ProductId{ get; set; }

        [Required]
        public int SaleId { get; set; }
    }
}
