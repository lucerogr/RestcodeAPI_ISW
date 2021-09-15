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
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        public readonly IUnitOfWork _unitOfWork;

        public PublicationService(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Publication>> ListAsync()
        {
            return await _publicationRepository.ListAsync();
        }

        public async Task<PublicationResponse> GetByIdAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            return new PublicationResponse(existingPublication);
        }

        public async Task<PublicationResponse> SaveAsync(Publication publication)
        {
            try
            {
                await _publicationRepository.AddSync(publication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(publication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while saving publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> UpdateAsync(int id, Publication publication)
        {
            var existingPublication = await _publicationRepository.FindById(id);
            if (existingPublication == null)
                return new PublicationResponse("Publication not found");
            existingPublication.Description = publication.Description;
            existingPublication.PublishedDate = publication.PublishedDate;


            try
            {
                _publicationRepository.Update(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while updating publication: {ex.Message}");
            }
        }

        public async Task<PublicationResponse> DeleteAsync(int id)
        {
            var existingPublication = await _publicationRepository.FindById(id);
            if (existingPublication == null)
                return new PublicationResponse($"Publication not found");

            try
            {
                _publicationRepository.Remove(existingPublication);
                await _unitOfWork.CompleteAsync();
                return new PublicationResponse(existingPublication);
            }
            catch (Exception ex)
            {
                return new PublicationResponse($"An error ocurred while deleting publication: {ex.Message}");
            }
        }
    }
}
