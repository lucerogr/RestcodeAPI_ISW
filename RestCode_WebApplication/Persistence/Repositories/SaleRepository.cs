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
    public class SaleRepository : BaseRepository, ISaleRepository
    {
        public SaleRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Sale>> ListAsync()
        {

            return await _context.Sales.ToListAsync();
        }

        public async Task AddAsync(Sale sale)
        {
            await _context.Sales.AddAsync(sale);
        }

        public async Task<Sale> FindById(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public void Update(Sale sale)
        {
            _context.Sales.Update(sale);
        }

        public void Remove(Sale sale)
        {
            _context.Sales.Remove(sale);
        }
    }
}
