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
    public class ConsultantRepository : BaseRepository, IConsultantRepository
    {
        public ConsultantRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Consultant consultant)
        {
            await _context.Consultants.AddAsync(consultant);
        }

        public async Task<Consultant> FindById(int id)
        {
            return await _context.Consultants.FindAsync(id);
        }

        public async Task<IEnumerable<Consultant>> ListAsync()
        {
            return await _context.Consultants.ToListAsync();
        }

        public void Remove(Consultant consultant)
        {
            _context.Consultants.Remove(consultant);
        }

        public void Update(Consultant consultant)
        {
            _context.Consultants.Update(consultant);
        }
    }
}
