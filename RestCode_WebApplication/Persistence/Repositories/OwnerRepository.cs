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
    public class OwnerRepository : BaseRepository, IOwnerRepository
    {
        public OwnerRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<Owner>> ListAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task<Owner> FindById(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public void Update(Owner owner)
        {
            _context.Owners.Update(owner);
        }

        public void Remove(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

    }
}
