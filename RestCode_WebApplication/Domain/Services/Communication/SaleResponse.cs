using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class SaleResponse : BaseResponse<Sale>
    {
        public SaleResponse(string message) : base(message) { }
        public SaleResponse(Sale sale) : base(sale) { }

    }
}
