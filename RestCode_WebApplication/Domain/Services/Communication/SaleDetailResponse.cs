using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class SaleDetailResponse : BaseResponse<SaleDetail>
    {
        public SaleDetailResponse(SaleDetail saleDetail) : base(saleDetail)
        {
        }

        public SaleDetailResponse(string message) : base(message)
        {

        }
    }
}
