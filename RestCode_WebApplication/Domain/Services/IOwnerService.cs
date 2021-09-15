using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> ListAsync();
        Task<OwnerResponse> GetByIdAsync(int id);
        Task<OwnerResponse> SaveAsync(Owner owner);
        Task<OwnerResponse> UpdateAsync(int id, Owner owner);
        Task<OwnerResponse> DeleteAsync(int id);
    }
}
