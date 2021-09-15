using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            _commentRepository = commentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> ListAsync()
        {
            return await _commentRepository.ListAsync();
        }

        public async Task<IEnumerable<Comment>> ListByPublicationIdAsync(int publicationId)
        {
            return await _commentRepository.ListByPublicationIdAsync(publicationId);
        }

        public async Task<CommentResponse> GetByIdAsync(int id)
        {
            var existingComment = await _commentRepository.FindById(id);
            if (existingComment == null)
                return new CommentResponse("Comment not found");
            return new CommentResponse(existingComment);
        }

        public async Task<CommentResponse> SaveAsync(Comment comment)
        {
            try
            {
                await _commentRepository.AddSync(comment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(comment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while saving comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _commentRepository.FindById(id);
            if (existingComment == null)
                return new CommentResponse("Comment not found");
            existingComment.Description = comment.Description;
            existingComment.PublicationId = comment.PublicationId;
            existingComment.OwnerId = comment.OwnerId;
            existingComment.ConsultantId = comment.ConsultantId;
            try
            {
                _commentRepository.Update(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while updating comment: {ex.Message}");
            }
        }

        public async Task<CommentResponse> DeleteAsync(int id)
        {
            var existingComment = await _commentRepository.FindById(id);
            if (existingComment == null)
                return new CommentResponse($"Comment not found");

            try
            {
                _commentRepository.Remove(existingComment);
                await _unitOfWork.CompleteAsync();
                return new CommentResponse(existingComment);
            }
            catch (Exception ex)
            {
                return new CommentResponse($"An error ocurred while deleting comment: {ex.Message}");
            }
        }
    }
}
