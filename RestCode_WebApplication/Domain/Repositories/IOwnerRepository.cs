using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> ListAsync();
        Task AddAsync(Owner owner);
        Task<Owner> FindById(int id);
        void Update(Owner owner);
        void Remove(Owner owner);
    }
}
