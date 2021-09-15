using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface IPublicationRepository
    {
        Task<IEnumerable<Publication>> ListAsync();
        Task AddSync(Publication publication);
        Task<Publication> FindById(int id);
        void Update(Publication publication);
        void Remove(Publication publication);
    }
}
