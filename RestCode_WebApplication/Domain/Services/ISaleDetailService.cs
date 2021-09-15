using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface ISaleDetailService
    {
        Task<IEnumerable<SaleDetail>> ListAsync();
        Task<SaleDetailResponse> GetByIdAsync(int id);
        Task<SaleDetailResponse> SaveAsync(SaleDetail saleDetail);
        Task<SaleDetailResponse> UpdateAsync(int id, SaleDetail saleDetail);
        Task<SaleDetailResponse> DeleteAsync(int id);
    }
}
