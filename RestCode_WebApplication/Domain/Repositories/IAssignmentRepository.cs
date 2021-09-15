using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> ListAsync();
        Task AddAsync(Assignment assignment);
        Task<Assignment> FindById(int id);
        void Update(Assignment assignment);
        void Remove(Assignment assignment);

    }
}
