using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IConsultantService
    {
        Task<IEnumerable<Consultant>> ListAsync();
        Task<ConsultantResponse> GetByIdAsync(int id);
        Task<ConsultantResponse> SaveAsync(Consultant consultant);
        Task<ConsultantResponse> UpdateAsync(int id, Consultant consultant);
        Task<ConsultantResponse> DeleteAsync(int id);
       
    }
}
 
