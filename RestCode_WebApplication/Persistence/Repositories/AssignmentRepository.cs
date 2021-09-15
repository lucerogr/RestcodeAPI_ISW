using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Persistence.Contexts;
using RestCode_WebApplication.Domain.Repositories;

namespace RestCode_WebApplication.Persistence.Repositories
{
    public class AssignmentRepository : BaseRepository, IAssignmentRepository
    {
        public AssignmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Assignment assignment)
        {
            await _context.Assignments.AddAsync(assignment);
        }

        public async Task<Assignment> FindById(int id)
        {
            return await _context.Assignments.FindAsync(id);
        }

        public async Task<IEnumerable<Assignment>> ListAsync()
        {
            return await _context.Assignments.ToListAsync();
        }

        public void Remove(Assignment assignment)
        {
            _context.Assignments.Remove(assignment);
        }

        public void Update(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
        }
    }
}
