using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class ProductResponse : BaseResponse<Product>
    {
        public ProductResponse(Product product) : base(product)
        {
        }

        public ProductResponse(string message) : base(message)
        {

        }
    }
}
