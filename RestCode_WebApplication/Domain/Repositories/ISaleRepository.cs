using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> ListAsync();
        Task AddAsync(Sale sale);
        Task<Sale> FindById(int id);
        void Update(Sale sale);
        void Remove(Sale sale);
    }
}
