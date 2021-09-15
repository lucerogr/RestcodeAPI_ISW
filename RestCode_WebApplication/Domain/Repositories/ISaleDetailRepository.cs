using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface ISaleDetailRepository
    {
        Task<IEnumerable<SaleDetail>> ListAsync();
        Task AddAsync(SaleDetail saleDetail);
        Task<SaleDetail> FindById(int id);
        void Update(SaleDetail saleDetail);
        void Remove(SaleDetail saleDetail);
    }
}
