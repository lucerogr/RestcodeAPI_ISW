using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestCode_WebApplication.Domain.Models;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IConsultancyRepository
    {
        Task<IEnumerable<Consultancy>> ListAsync();
        Task AddAsync(Consultancy consultancy);
        Task<Consultancy> FindById(int id);
        void Update(Consultancy consultancy);
        void Remove(Consultancy consultancy);
    }
}
