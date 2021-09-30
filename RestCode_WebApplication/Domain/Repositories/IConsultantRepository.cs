using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IConsultantRepository
    {
        Task<IEnumerable<Consultant>> ListAsync();
        Task AddAsync(Consultant consultant);
        Task<Consultant> FindById(int id);
        Task<Consultant> FindByMail(string mail);
        void Update(Consultant consultant);
        void Remove(Consultant consultant);
    }
}
