using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communication;

namespace RestCode_WebApplication.Domain.Services
{
    public interface IAssignmentService
    {

        Task<IEnumerable<Assignment>> ListAsync();
        Task<AssignmentResponse> GetByIdAsync(int id);
        Task<AssignmentResponse> SaveAsync(Assignment assignment);
        Task<AssignmentResponse> UpdateAsync(int id, Assignment assignment);
        Task<AssignmentResponse> DeleteAsync(int id);
    }
}
