using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services.Communications
{
    public class CategoryResponse : BaseResponse<Category>
    {

        public CategoryResponse(string message) : base(message) { }

        public CategoryResponse(Category category) : base(category) { }

    }
}
