using RestCode_WebApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task AddSync(Comment comment);
        Task<Comment> FindById(int id);
        void Update(Comment comment);
        void Remove(Comment comment);
    }
}
