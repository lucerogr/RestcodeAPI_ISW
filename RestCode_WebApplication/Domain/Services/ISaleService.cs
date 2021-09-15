using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface ISaleService
    {
        Task<IEnumerable<Sale>> ListAsync();
        Task<SaleResponse> GetByIdAsync(int id);
        Task<SaleResponse> SaveAsync(Sale sale);
        Task<SaleResponse> UpdateAsync(int id, Sale sale);
        Task<SaleResponse> DeleteAsync(int id);
    }
}
