using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Persistence.Repositories
{
    public class SaleDetailRepository : BaseRepository, ISaleDetailRepository
    {
        public SaleDetailRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<SaleDetail>> ListAsync()
        {
            return await _context.SaleDetails.ToListAsync();
        }

        public async Task AddAsync(SaleDetail saleDetail)
        {
            await _context.SaleDetails.AddAsync(saleDetail);
        }

        public async Task<SaleDetail> FindById(int id)
        {
            return await _context.SaleDetails.FindAsync(id);
        }
        public void Update(SaleDetail saleDetail)
        {
            _context.SaleDetails.Update(saleDetail);
        }

        public  void Remove(SaleDetail saleDetail)
        {
            _context.SaleDetails.Remove(saleDetail);
            
        }
    }
}
