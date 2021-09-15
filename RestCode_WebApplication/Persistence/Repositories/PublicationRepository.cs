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
    public class PublicationRepository : BaseRepository, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context) { }

        public async Task AddSync(Publication publication)
        {
            await _context.Publications.AddAsync(publication);
        }

        public async Task<Publication> FindById(int id)
        {
            return await _context.Publications.FindAsync(id);
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _context.Publications.ToListAsync();
        }

        public void Remove(Publication publication)
        {
            _context.Publications.Remove(publication);
        }

        public void Update(Publication publication)
        {
            _context.Publications.Update(publication);
        }
    }
}
