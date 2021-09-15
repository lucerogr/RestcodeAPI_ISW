using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;

namespace RestCode_WebApplication.Persistence.Repositories
{
    public class ConsultancyRepository : BaseRepository, IConsultancyRepository
    {
        public ConsultancyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Consultancy>> ListAsync()
        {
            return await _context.Consultancies.ToListAsync();
        }

        public async Task AddAsync(Consultancy consultancy)
        {
            await _context.Consultancies.AddAsync(consultancy);
        }

        public async Task<Consultancy> FindById(int id)
        {
            return await _context.Consultancies.FindAsync(id);
        }

        public void Update(Consultancy consultancy)
        {
            _context.Consultancies.Update(consultancy);
        }

        public void Remove(Consultancy consultancy)
        {
            _context.Consultancies.Remove(consultancy);
        }
 
    }
}
