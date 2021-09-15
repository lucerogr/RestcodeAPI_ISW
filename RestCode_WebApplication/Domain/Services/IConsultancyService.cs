using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communication;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IConsultancyService
    {
        Task<IEnumerable<Consultancy>> ListAsync();
        Task<ConsultancyResponse> GetByIdAsync(int id);
        Task<ConsultancyResponse> SaveAsync(Consultancy consultancy);
        Task<ConsultancyResponse> UpdateAsync(int id, Consultancy consultancy);
        Task<ConsultancyResponse> DeleteAsync(int id);

    }
}
