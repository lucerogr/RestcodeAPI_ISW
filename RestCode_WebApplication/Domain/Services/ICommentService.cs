using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Domain.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListAsync();
        Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId);
        Task<CommentResponse> GetByIdAsync(int id);
        Task<CommentResponse> SaveAsync(Comment comment);
        Task<CommentResponse> UpdateAsync(int id, Comment comment);
        Task<CommentResponse> DeleteAsync(int id);
    }
}
